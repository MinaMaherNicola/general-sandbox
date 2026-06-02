#!/usr/bin/env bash
# Start the Learning Progress app. On first run, creates a venv and installs deps.
# Backend and frontend are served by the same uvicorn process — no separate frontend server.
set -euo pipefail

cd "$(dirname "$0")"

HOST="${HOST:-127.0.0.1}"
PORT="${PORT:-8000}"

if [ ! -d .venv ]; then
    echo "→ Creating virtual environment in .venv/"
    python3 -m venv .venv
    .venv/bin/pip install --quiet --upgrade pip
    echo "→ Installing dependencies"
    .venv/bin/pip install --quiet -r requirements.txt
fi

echo "→ Starting server at http://${HOST}:${PORT}"
exec .venv/bin/uvicorn app.main:app --host "$HOST" --port "$PORT" --reload
