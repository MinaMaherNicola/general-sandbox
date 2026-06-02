import sqlite3
from datetime import datetime, timezone

from fastapi import APIRouter, Depends, HTTPException, Response, status

from .database import get_db
from .schemas import TopicCreate, TopicOut, TopicUpdate

router = APIRouter()


def _row_to_topic(row: sqlite3.Row) -> TopicOut:
    return TopicOut.model_validate(dict(row))


def _now_iso() -> str:
    return datetime.now(timezone.utc).isoformat()


@router.get("/health")
def health() -> dict[str, str]:
    return {"status": "ok"}


@router.get("/topics", response_model=list[TopicOut])
def list_topics(db: sqlite3.Connection = Depends(get_db)) -> list[TopicOut]:
    rows = db.execute(
        "SELECT * FROM learning_topics ORDER BY updated_at DESC, id DESC"
    ).fetchall()
    return [_row_to_topic(r) for r in rows]


@router.get("/topics/{topic_id}", response_model=TopicOut)
def get_topic(topic_id: int, db: sqlite3.Connection = Depends(get_db)) -> TopicOut:
    row = db.execute(
        "SELECT * FROM learning_topics WHERE id = ?", (topic_id,)
    ).fetchone()
    if row is None:
        raise HTTPException(status_code=404, detail="Topic not found")
    return _row_to_topic(row)


@router.post(
    "/topics",
    response_model=TopicOut,
    status_code=status.HTTP_201_CREATED,
)
def create_topic(
    payload: TopicCreate, db: sqlite3.Connection = Depends(get_db)
) -> TopicOut:
    now = _now_iso()
    cur = db.execute(
        """
        INSERT INTO learning_topics
            (name, type, total_units, completed_units, created_at, updated_at,
             pace_units, pace_period)
        VALUES (?, ?, ?, ?, ?, ?, ?, ?)
        """,
        (
            payload.name,
            payload.type,
            payload.total_units,
            payload.completed_units,
            now,
            now,
            payload.pace_units,
            payload.pace_period,
        ),
    )
    db.commit()
    row = db.execute(
        "SELECT * FROM learning_topics WHERE id = ?", (cur.lastrowid,)
    ).fetchone()
    return _row_to_topic(row)


@router.put("/topics/{topic_id}", response_model=TopicOut)
def update_topic(
    topic_id: int,
    payload: TopicUpdate,
    db: sqlite3.Connection = Depends(get_db),
) -> TopicOut:
    existing = db.execute(
        "SELECT id FROM learning_topics WHERE id = ?", (topic_id,)
    ).fetchone()
    if existing is None:
        raise HTTPException(status_code=404, detail="Topic not found")
    db.execute(
        """
        UPDATE learning_topics
        SET name = ?, type = ?, total_units = ?, completed_units = ?,
            pace_units = ?, pace_period = ?, updated_at = ?
        WHERE id = ?
        """,
        (
            payload.name,
            payload.type,
            payload.total_units,
            payload.completed_units,
            payload.pace_units,
            payload.pace_period,
            _now_iso(),
            topic_id,
        ),
    )
    db.commit()
    row = db.execute(
        "SELECT * FROM learning_topics WHERE id = ?", (topic_id,)
    ).fetchone()
    return _row_to_topic(row)


@router.delete("/topics/{topic_id}", status_code=status.HTTP_204_NO_CONTENT)
def delete_topic(
    topic_id: int, db: sqlite3.Connection = Depends(get_db)
) -> Response:
    cur = db.execute("DELETE FROM learning_topics WHERE id = ?", (topic_id,))
    db.commit()
    if cur.rowcount == 0:
        raise HTTPException(status_code=404, detail="Topic not found")
    return Response(status_code=status.HTTP_204_NO_CONTENT)
