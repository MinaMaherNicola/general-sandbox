import math
from typing import Literal

from pydantic import BaseModel, ConfigDict, Field, computed_field, model_validator

PacePeriod = Literal["day", "week", "month"]

_DAYS_PER_PERIOD: dict[PacePeriod, int] = {"day": 1, "week": 7, "month": 30}


class TopicBase(BaseModel):
    model_config = ConfigDict(str_strip_whitespace=True)

    name: str = Field(..., min_length=1, max_length=200)
    type: Literal["book", "videos"]
    total_units: int = Field(..., ge=0, le=10_000)
    completed_units: int = Field(..., ge=0, le=10_000)
    pace_units: int | None = Field(default=None, gt=0, le=10_000)
    pace_period: PacePeriod | None = None

    @model_validator(mode="after")
    def _validate(self) -> "TopicBase":
        if self.completed_units > self.total_units:
            raise ValueError("completed_units cannot exceed total_units")
        # Both-or-neither rule. Lives only in Pydantic because SQLite
        # ALTER TABLE ADD COLUMN can't add a table-level CHECK across columns.
        if (self.pace_units is None) != (self.pace_period is None):
            raise ValueError(
                "pace_units and pace_period must both be provided or both omitted"
            )
        return self


class TopicCreate(TopicBase):
    pass


class TopicUpdate(TopicBase):
    pass


class TopicOut(TopicBase):
    id: int
    created_at: str
    updated_at: str

    @computed_field
    @property
    def completion_percentage(self) -> float:
        if self.total_units == 0:
            return 0.0
        return round(self.completed_units / self.total_units * 100, 1)

    @computed_field
    @property
    def remaining_units(self) -> int:
        return max(0, self.total_units - self.completed_units)

    @computed_field
    @property
    def is_completed(self) -> bool:
        return self.total_units > 0 and self.completed_units >= self.total_units

    @computed_field
    @property
    def estimated_periods_to_finish(self) -> float | None:
        if self.pace_units is None or self.pace_period is None:
            return None
        if self.total_units == 0:
            return None
        if self.remaining_units == 0:
            return 0.0
        return round(self.remaining_units / self.pace_units, 2)

    @computed_field
    @property
    def estimated_days_to_finish(self) -> int | None:
        if self.pace_units is None or self.pace_period is None:
            return None
        if self.total_units == 0:
            return None
        if self.remaining_units == 0:
            return 0
        days_per_period = _DAYS_PER_PERIOD[self.pace_period]
        return math.ceil(self.remaining_units / self.pace_units * days_per_period)
