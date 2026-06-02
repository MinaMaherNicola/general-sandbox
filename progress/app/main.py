from contextlib import asynccontextmanager
from pathlib import Path

from fastapi import FastAPI
from fastapi.staticfiles import StaticFiles

from . import database, routes

BASE_DIR = Path(__file__).resolve().parent.parent
FRONTEND_DIR = BASE_DIR / "frontend"


@asynccontextmanager
async def lifespan(_app: FastAPI):
    database.init_db()
    yield


# LOCAL ONLY — no auth. Bind to 127.0.0.1 in production; do not expose to network.
app = FastAPI(title="Learning Progress", lifespan=lifespan)
app.include_router(routes.router, prefix="/api")
app.mount("/", StaticFiles(directory=FRONTEND_DIR, html=True), name="frontend")
