"""Dump all topics to JSON on stdout. Useful as a recovery aid before resolving
a git merge conflict on `data/app.db`.

Run from the project root:
    python scripts/export.py > backup.json
"""
import json
from pathlib import Path
import sys

sys.path.insert(0, str(Path(__file__).resolve().parent.parent))

from app import database  # noqa: E402


def main() -> None:
    if not database.DB_PATH.exists():
        print(f"No database found at {database.DB_PATH}", file=sys.stderr)
        sys.exit(1)
    conn = database.get_connection()
    try:
        rows = conn.execute("SELECT * FROM learning_topics ORDER BY id").fetchall()
        topics = [dict(r) for r in rows]
        json.dump(topics, sys.stdout, indent=2)
        sys.stdout.write("\n")
    finally:
        conn.close()


if __name__ == "__main__":
    main()
