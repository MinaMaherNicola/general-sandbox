import sqlite3
from contextlib import closing
from pathlib import Path
from typing import Iterator

BASE_DIR = Path(__file__).resolve().parent.parent
DB_PATH: Path = BASE_DIR / "data" / "app.db"

SCHEMA_SQL = """
CREATE TABLE IF NOT EXISTS learning_topics (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    type TEXT NOT NULL CHECK(type IN ('book', 'videos')),
    total_units INTEGER NOT NULL CHECK(total_units >= 0),
    completed_units INTEGER NOT NULL CHECK(
        completed_units >= 0 AND completed_units <= total_units
    ),
    created_at TEXT NOT NULL,
    updated_at TEXT NOT NULL,
    pace_units INTEGER CHECK(pace_units IS NULL OR pace_units > 0),
    pace_period TEXT CHECK(pace_period IS NULL OR pace_period IN ('day', 'week', 'month'))
);
"""

# In-place migrations applied after CREATE TABLE IF NOT EXISTS so existing
# data/app.db files pick up new optional columns without losing rows.
_MIGRATIONS: tuple[tuple[str, str], ...] = (
    (
        "pace_units",
        "ALTER TABLE learning_topics ADD COLUMN pace_units INTEGER "
        "CHECK(pace_units IS NULL OR pace_units > 0)",
    ),
    (
        "pace_period",
        "ALTER TABLE learning_topics ADD COLUMN pace_period TEXT "
        "CHECK(pace_period IS NULL OR pace_period IN ('day', 'week', 'month'))",
    ),
)


def get_connection() -> sqlite3.Connection:
    DB_PATH.parent.mkdir(parents=True, exist_ok=True)
    conn = sqlite3.connect(DB_PATH)
    conn.row_factory = sqlite3.Row
    conn.execute("PRAGMA foreign_keys = ON")
    return conn


def init_db() -> None:
    with closing(get_connection()) as conn:
        conn.executescript(SCHEMA_SQL)
        existing = {row["name"] for row in conn.execute("PRAGMA table_info(learning_topics)")}
        for column, ddl in _MIGRATIONS:
            if column in existing:
                continue
            try:
                conn.execute(ddl)
            except sqlite3.OperationalError as e:
                if "duplicate column" not in str(e).lower():
                    raise
        conn.commit()


def get_db() -> Iterator[sqlite3.Connection]:
    conn = get_connection()
    try:
        yield conn
    finally:
        conn.close()
