import sqlite3
from contextlib import closing

import pytest

from app import database

# Pre-existing schema before the pace columns were added. Copied as a literal
# (not imported) so we genuinely simulate an old DB on disk.
OLD_SCHEMA = """
CREATE TABLE learning_topics (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    type TEXT NOT NULL CHECK(type IN ('book', 'videos')),
    total_units INTEGER NOT NULL CHECK(total_units >= 0),
    completed_units INTEGER NOT NULL CHECK(
        completed_units >= 0 AND completed_units <= total_units
    ),
    created_at TEXT NOT NULL,
    updated_at TEXT NOT NULL
);
"""


def test_init_db_migrates_old_schema_in_place(tmp_path, monkeypatch):
    old_db = tmp_path / "old.db"
    monkeypatch.setattr(database, "DB_PATH", old_db)

    with closing(sqlite3.connect(old_db)) as conn:
        conn.executescript(OLD_SCHEMA)
        conn.execute(
            "INSERT INTO learning_topics "
            "(name, type, total_units, completed_units, created_at, updated_at) "
            "VALUES (?, ?, ?, ?, ?, ?)",
            ("Legacy Book", "book", 10, 3, "2024-01-01T00:00:00+00:00", "2024-01-01T00:00:00+00:00"),
        )
        conn.commit()

    database.init_db()

    with closing(sqlite3.connect(old_db)) as conn:
        conn.row_factory = sqlite3.Row
        cols = {r["name"] for r in conn.execute("PRAGMA table_info(learning_topics)")}
        assert "pace_units" in cols
        assert "pace_period" in cols

        row = conn.execute("SELECT * FROM learning_topics").fetchone()
        assert row["name"] == "Legacy Book"
        assert row["total_units"] == 10
        assert row["completed_units"] == 3
        assert row["pace_units"] is None
        assert row["pace_period"] is None

    # Idempotent: a second startup must not raise.
    database.init_db()

    # CHECK actually enforced on the migrated table.
    with closing(sqlite3.connect(old_db)) as conn:
        with pytest.raises(sqlite3.IntegrityError):
            conn.execute(
                "INSERT INTO learning_topics "
                "(name, type, total_units, completed_units, created_at, updated_at, "
                " pace_units, pace_period) "
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?)",
                ("Bad", "book", 1, 0, "x", "x", -1, "week"),
            )
