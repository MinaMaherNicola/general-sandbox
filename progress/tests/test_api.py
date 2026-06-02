VALID_BOOK = {
    "name": "Design Patterns",
    "type": "book",
    "total_units": 20,
    "completed_units": 5,
}
VALID_VIDEOS = {
    "name": "Docker Course",
    "type": "videos",
    "total_units": 10,
    "completed_units": 7,
}


def test_health(client):
    resp = client.get("/api/health")
    assert resp.status_code == 200
    assert resp.json() == {"status": "ok"}


def test_create_book_returns_201_with_percentage(client):
    resp = client.post("/api/topics", json=VALID_BOOK)
    assert resp.status_code == 201
    data = resp.json()
    assert data["name"] == "Design Patterns"
    assert data["type"] == "book"
    assert data["total_units"] == 20
    assert data["completed_units"] == 5
    assert data["completion_percentage"] == 25.0
    assert data["id"] >= 1
    assert data["created_at"] == data["updated_at"]


def test_create_videos_percentage(client):
    resp = client.post("/api/topics", json=VALID_VIDEOS)
    assert resp.status_code == 201
    assert resp.json()["completion_percentage"] == 70.0


def test_total_zero_percentage_is_zero(client):
    payload = {**VALID_BOOK, "total_units": 0, "completed_units": 0}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 201
    assert resp.json()["completion_percentage"] == 0.0


def test_rejects_empty_name(client):
    payload = {**VALID_BOOK, "name": ""}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 422


def test_rejects_whitespace_only_name(client):
    payload = {**VALID_BOOK, "name": "   "}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 422


def test_strips_name_whitespace(client):
    payload = {**VALID_BOOK, "name": "  Clean Architecture  "}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 201
    assert resp.json()["name"] == "Clean Architecture"


def test_rejects_negative_total(client):
    payload = {**VALID_BOOK, "total_units": -1}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 422


def test_rejects_negative_completed(client):
    payload = {**VALID_BOOK, "completed_units": -3}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 422


def test_rejects_completed_greater_than_total(client):
    payload = {**VALID_BOOK, "total_units": 5, "completed_units": 6}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 422
    detail = resp.json()["detail"]
    assert any("completed_units cannot exceed total_units" in str(d) for d in detail)


def test_rejects_invalid_type(client):
    payload = {**VALID_BOOK, "type": "podcast"}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 422


def test_list_returns_topics_ordered(client):
    a = client.post("/api/topics", json=VALID_BOOK).json()
    b = client.post("/api/topics", json=VALID_VIDEOS).json()
    resp = client.get("/api/topics")
    assert resp.status_code == 200
    topics = resp.json()
    assert len(topics) == 2
    ids = [t["id"] for t in topics]
    assert ids == [b["id"], a["id"]]


def test_get_one_topic(client):
    created = client.post("/api/topics", json=VALID_BOOK).json()
    resp = client.get(f"/api/topics/{created['id']}")
    assert resp.status_code == 200
    assert resp.json()["id"] == created["id"]


def test_get_missing_returns_404(client):
    resp = client.get("/api/topics/9999")
    assert resp.status_code == 404


def test_update_topic_bumps_updated_at(client):
    created = client.post("/api/topics", json=VALID_BOOK).json()
    new_payload = {**VALID_BOOK, "completed_units": 10}
    resp = client.put(f"/api/topics/{created['id']}", json=new_payload)
    assert resp.status_code == 200
    updated = resp.json()
    assert updated["completed_units"] == 10
    assert updated["completion_percentage"] == 50.0
    assert updated["created_at"] == created["created_at"]
    assert updated["updated_at"] >= created["updated_at"]


def test_update_validates_payload(client):
    created = client.post("/api/topics", json=VALID_BOOK).json()
    bad = {**VALID_BOOK, "total_units": 5, "completed_units": 10}
    resp = client.put(f"/api/topics/{created['id']}", json=bad)
    assert resp.status_code == 422


def test_update_missing_returns_404(client):
    resp = client.put("/api/topics/9999", json=VALID_BOOK)
    assert resp.status_code == 404


def test_delete_removes_topic(client):
    created = client.post("/api/topics", json=VALID_BOOK).json()
    resp = client.delete(f"/api/topics/{created['id']}")
    assert resp.status_code == 204
    follow = client.get(f"/api/topics/{created['id']}")
    assert follow.status_code == 404


def test_delete_missing_returns_404(client):
    resp = client.delete("/api/topics/9999")
    assert resp.status_code == 404


def test_name_length_cap(client):
    payload = {**VALID_BOOK, "name": "x" * 201}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 422


def test_persistence_across_requests(client):
    a = client.post("/api/topics", json=VALID_BOOK).json()
    b = client.post("/api/topics", json=VALID_VIDEOS).json()
    listing = client.get("/api/topics").json()
    ids = {t["id"] for t in listing}
    assert {a["id"], b["id"]} == ids


# --- Time Management (pace + estimates) ------------------------------------


def test_create_with_pace_returns_estimates(client):
    payload = {
        "name": "Clean Architecture",
        "type": "book",
        "total_units": 20,
        "completed_units": 0,
        "pace_units": 1,
        "pace_period": "week",
    }
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 201
    data = resp.json()
    assert data["pace_units"] == 1
    assert data["pace_period"] == "week"
    assert data["remaining_units"] == 20
    assert data["is_completed"] is False
    assert data["estimated_periods_to_finish"] == 20.0
    assert data["estimated_days_to_finish"] == 140


def test_create_with_pace_partial_remaining(client):
    payload = {
        "name": "DDD",
        "type": "book",
        "total_units": 20,
        "completed_units": 5,
        "pace_units": 1,
        "pace_period": "week",
    }
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 201
    data = resp.json()
    assert data["remaining_units"] == 15
    assert data["estimated_periods_to_finish"] == 15.0
    assert data["estimated_days_to_finish"] == 105


def test_create_videos_with_pace(client):
    payload = {
        "name": "K8s Course",
        "type": "videos",
        "total_units": 10,
        "completed_units": 4,
        "pace_units": 2,
        "pace_period": "week",
    }
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 201
    data = resp.json()
    assert data["remaining_units"] == 6
    assert data["estimated_periods_to_finish"] == 3.0
    assert data["estimated_days_to_finish"] == 21


def test_create_without_pace_returns_nulls(client):
    resp = client.post("/api/topics", json=VALID_BOOK)
    assert resp.status_code == 201
    data = resp.json()
    assert data["pace_units"] is None
    assert data["pace_period"] is None
    assert data["estimated_periods_to_finish"] is None
    assert data["estimated_days_to_finish"] is None
    assert data["remaining_units"] == 15


def test_rejects_pace_units_only(client):
    payload = {**VALID_BOOK, "pace_units": 1}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 422


def test_rejects_pace_period_only(client):
    payload = {**VALID_BOOK, "pace_period": "week"}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 422


def test_rejects_zero_pace_units(client):
    payload = {**VALID_BOOK, "pace_units": 0, "pace_period": "week"}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 422


def test_rejects_negative_pace_units(client):
    payload = {**VALID_BOOK, "pace_units": -3, "pace_period": "week"}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 422


def test_rejects_invalid_pace_period(client):
    payload = {**VALID_BOOK, "pace_units": 1, "pace_period": "year"}
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 422


def test_completed_topic_with_pace(client):
    payload = {
        "name": "Finished Book",
        "type": "book",
        "total_units": 5,
        "completed_units": 5,
        "pace_units": 1,
        "pace_period": "week",
    }
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 201
    data = resp.json()
    assert data["is_completed"] is True
    assert data["remaining_units"] == 0
    assert data["estimated_periods_to_finish"] == 0.0
    assert data["estimated_days_to_finish"] == 0


def test_total_zero_with_pace_returns_null_estimates(client):
    payload = {
        "name": "Empty",
        "type": "book",
        "total_units": 0,
        "completed_units": 0,
        "pace_units": 1,
        "pace_period": "week",
    }
    resp = client.post("/api/topics", json=payload)
    assert resp.status_code == 201
    data = resp.json()
    assert data["is_completed"] is False
    assert data["estimated_periods_to_finish"] is None
    assert data["estimated_days_to_finish"] is None


def test_update_can_add_pace_later(client):
    created = client.post("/api/topics", json=VALID_BOOK).json()
    new_payload = {**VALID_BOOK, "pace_units": 2, "pace_period": "week"}
    resp = client.put(f"/api/topics/{created['id']}", json=new_payload)
    assert resp.status_code == 200
    data = resp.json()
    assert data["pace_units"] == 2
    assert data["pace_period"] == "week"
    assert data["estimated_days_to_finish"] is not None


def test_update_can_clear_pace(client):
    paced = {**VALID_BOOK, "pace_units": 1, "pace_period": "week"}
    created = client.post("/api/topics", json=paced).json()
    assert created["pace_units"] == 1
    cleared = {**VALID_BOOK, "pace_units": None, "pace_period": None}
    resp = client.put(f"/api/topics/{created['id']}", json=cleared)
    assert resp.status_code == 200
    data = resp.json()
    assert data["pace_units"] is None
    assert data["pace_period"] is None
    assert data["estimated_periods_to_finish"] is None
    assert data["estimated_days_to_finish"] is None
