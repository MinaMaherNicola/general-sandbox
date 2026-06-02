import pytest
from fastapi.testclient import TestClient

from app import database
from app.main import app


@pytest.fixture
def client(tmp_path, monkeypatch):
    test_db = tmp_path / "test.db"
    monkeypatch.setattr(database, "DB_PATH", test_db)
    with TestClient(app) as c:
        yield c
