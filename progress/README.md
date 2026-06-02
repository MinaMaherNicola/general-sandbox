# Learning Progress

A small full-stack dashboard for tracking your learning topics — books (by chapters) and video courses (by sections) — with progress bars and percentages. Data is stored in a single SQLite file so you can commit it to git and sync between devices.

## Stack

- **Backend:** FastAPI + Pydantic v2, stdlib `sqlite3` (no ORM).
- **Frontend:** Vanilla HTML/CSS/JS served by FastAPI as static files. No build step.
- **Storage:** SQLite at `data/app.db`.

## Prerequisites

- Python 3.10+
- git

## Quickstart

```bash
cd progress
./run.sh
```

That's it. The script creates a `.venv/` on first run, installs dependencies, and starts the server at [http://127.0.0.1:8000](http://127.0.0.1:8000). Backend API and frontend dashboard are served by the same process — there is no separate frontend server.

Override host/port if needed:

```bash
HOST=0.0.0.0 PORT=9000 ./run.sh
```

## Manual setup (if you don't want to use `run.sh`)

Prerequisites on Debian/Ubuntu: `sudo apt install python3-venv python3-pip`.

```bash
cd progress
python3 -m venv .venv
source .venv/bin/activate          # Windows: .venv\Scripts\activate
pip install -r requirements.txt
uvicorn app.main:app --reload
```

The first run creates `data/app.db` automatically. API docs (auto-generated) live at [http://127.0.0.1:8000/docs](http://127.0.0.1:8000/docs).

## Tests

```bash
pytest -v
```

## Optional: seed example data

```bash
python scripts/seed.py
```

Idempotent — does nothing if the database already has topics.

## Usage

1. Click **+ Add Topic**.
2. Enter a subject name, choose **Book** or **Video Course** — labels swap between *chapters* and *sections*.
3. Fill in total and completed counts. The dashboard shows a progress bar and percentage per topic.
4. Use **Edit** to update; **Delete** to remove (asks for confirmation).

Validation rules (enforced server-side):
- Name cannot be empty or only whitespace (max 200 chars).
- `total_units` and `completed_units` must be ≥ 0 and ≤ 10,000.
- `completed_units` cannot exceed `total_units`.
- `type` must be `book` or `videos`.
- If `total_units` is `0`, percentage is `0%` (no division error).

### Time Management (optional)

Each topic can carry a learning pace — e.g. *1 chapter per week* or *2 sections per day* — and the server will compute when you'll finish at that rate. Leave the pace fields blank to skip this entirely; existing topics without pace are unaffected.

Set `pace_units` (whole number > 0) together with `pace_period` (`day`, `week`, or `month`); setting one without the other is rejected with `422`. Every topic response also includes these computed fields:

- `remaining_units` — `max(0, total_units - completed_units)`.
- `is_completed` — `true` once you've hit the total (the card swaps the estimate for a *Completed* badge).
- `estimated_periods_to_finish` — remaining units divided by `pace_units`, or `null` if no pace is set / `total_units` is 0.
- `estimated_days_to_finish` — same calculation projected onto days (`day` = 1, `week` = 7, `month` = 30), rounded up.

Existing databases upgrade in place on startup — `init_db()` runs an idempotent `ALTER TABLE ADD COLUMN` migration so you don't lose any topics.

## API

| Method | Path                  | Description                          |
|--------|-----------------------|--------------------------------------|
| GET    | `/api/health`         | Liveness check.                      |
| GET    | `/api/topics`         | List all topics (newest first).      |
| GET    | `/api/topics/{id}`    | Get one topic; 404 if missing.       |
| POST   | `/api/topics`         | Create a topic. 201 + body.          |
| PUT    | `/api/topics/{id}`    | Replace a topic; 404 if missing.     |
| DELETE | `/api/topics/{id}`    | Delete a topic; 204 / 404.           |

Validation errors return `422` with a `detail` array of field/message pairs.

## Architecture

```
progress/
├── run.sh                One-shot start (creates venv, installs deps, runs uvicorn)
├── app/                  FastAPI app
│   ├── main.py           App factory + static mount; runs init_db() on startup
│   ├── database.py       SQLite connection, schema, get_db() dependency
│   ├── schemas.py        Pydantic models (request + response shapes)
│   └── routes.py         /api/topics CRUD + /api/health
├── frontend/             Static UI (served at /)
│   ├── index.html
│   ├── styles.css
│   └── app.js
├── data/app.db           SQLite database (committed to git)
├── scripts/seed.py       Idempotent example-data loader
├── scripts/export.py     JSON dump of all topics (recovery aid)
└── tests/                pytest + FastAPI TestClient
```

The FastAPI app registers `/api/*` routes first, then mounts the `frontend/` directory at `/`. The frontend talks to the API with `fetch`; the percentage is computed server-side on every response.

## Cross-device sync via GitHub

This app is single-user and single-process — there is no real-time sync. The `data/app.db` file is intentionally committed to git so you can move your progress between devices.

**Typical workflow:**

```bash
# Before using the app on a device:
git pull

# After making changes:
git add data/app.db
git commit -m "progress: update topics"
git push
```

**Conflict warning:** If two devices both edit topics before pulling, git will report a merge conflict on `data/app.db`. Since the database is a binary file, git cannot merge it automatically — you must pick one side and the other side's changes will be lost.

**Recovery procedure:**

1. **Before resolving**, on each device, export a JSON backup of that device's current state:
   ```bash
   python scripts/export.py > backup-$(hostname)-$(date +%s).json
   ```
2. Pick one side to keep:
   ```bash
   git checkout --theirs data/app.db   # keep the remote version
   # OR
   git checkout --ours data/app.db     # keep your local version
   git add data/app.db
   git commit
   ```
3. Manually re-create any lost topics from the discarded backup using the UI.

**Operational notes:**

- Run with a **single worker only**. Do not pass `--workers N` to uvicorn — SQLite serializes writes anyway and concurrent workers can collide on the file lock.
- The app binds to `127.0.0.1` by convention. There is **no authentication**. Do not expose the port to a network you don't trust.
- The transient SQLite sidecar files (`*.db-journal`, `*.db-wal`, `*.db-shm`) are git-ignored so a crashed write doesn't pollute the repo.

## Deliberate non-goals

No authentication, no PATCH endpoint (PUT is full replace), no unique-name constraint, no real-time sync, no Docker, no node build step. If you outgrow any of these, the schema in `app/database.py` and the routes in `app/routes.py` are small enough to extend.
