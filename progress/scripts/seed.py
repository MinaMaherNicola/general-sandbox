"""Populate the database with example topics. Idempotent: exits if any topics already exist.

Run from the project root:
    python scripts/seed.py
"""
from datetime import datetime, timezone
from pathlib import Path
import sys

sys.path.insert(0, str(Path(__file__).resolve().parent.parent))

from app import database  # noqa: E402

SEED_TOPICS = [
    ("Design Patterns", "book", 20, 5),
    ("Clean Architecture", "book", 18, 12),
    ("Docker Course", "videos", 10, 7),
    ("FastAPI Tutorial", "videos", 24, 24),
]


def main() -> None:
    database.init_db()
    conn = database.get_connection()
    try:
        existing = conn.execute("SELECT COUNT(*) FROM learning_topics").fetchone()[0]
        if existing > 0:
            print(f"Database already has {existing} topic(s); skipping seed.")
            return
        now = datetime.now(timezone.utc).isoformat()
        conn.executemany(
            """
            INSERT INTO learning_topics
                (name, type, total_units, completed_units, created_at, updated_at)
            VALUES (?, ?, ?, ?, ?, ?)
            """,
            [(name, t, total, done, now, now) for name, t, total, done in SEED_TOPICS],
        )
        conn.commit()
        print(f"Inserted {len(SEED_TOPICS)} seed topics into {database.DB_PATH}.")
    finally:
        conn.close()


if __name__ == "__main__":
    main()
