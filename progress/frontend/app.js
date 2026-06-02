const API = "/api/topics";

const els = {
  loading: document.getElementById("loading-state"),
  empty: document.getElementById("empty-state"),
  grid: document.getElementById("topics-grid"),
  errorBanner: document.getElementById("error-banner"),
  errorMessage: document.getElementById("error-message"),
  errorDismiss: document.getElementById("error-dismiss"),
  addBtn: document.getElementById("add-btn"),
  modal: document.getElementById("modal"),
  modalTitle: document.getElementById("modal-title"),
  form: document.getElementById("topic-form"),
  nameInput: document.getElementById("name"),
  typeInput: document.getElementById("type"),
  totalInput: document.getElementById("total_units"),
  completedInput: document.getElementById("completed_units"),
  totalLabel: document.getElementById("total-label"),
  completedLabel: document.getElementById("completed-label"),
  paceUnitsInput: document.getElementById("pace_units"),
  paceUnitsLabel: document.getElementById("pace-units-label"),
  pacePeriodInput: document.getElementById("pace_period"),
  formError: document.getElementById("form-error"),
  saveBtn: document.getElementById("save-btn"),
  template: document.getElementById("topic-card-template"),
};

let editingId = null;

function unitWord(type) {
  return type === "videos" ? "sections" : "chapters";
}

function unitSingular(type) {
  return type === "videos" ? "section" : "chapter";
}

function formatPeriods(n) {
  const rounded = Math.round(n * 10) / 10;
  return Number.isInteger(rounded) ? `${rounded}` : `${rounded.toFixed(1)}`;
}

function formatRelative(iso) {
  const then = new Date(iso);
  if (Number.isNaN(then.getTime())) return iso;
  const diffSec = Math.floor((Date.now() - then.getTime()) / 1000);
  if (diffSec < 60) return "just now";
  if (diffSec < 3600) return `${Math.floor(diffSec / 60)}m ago`;
  if (diffSec < 86400) return `${Math.floor(diffSec / 3600)}h ago`;
  if (diffSec < 604800) return `${Math.floor(diffSec / 86400)}d ago`;
  return then.toLocaleDateString();
}

function formatPercent(p) {
  if (Number.isInteger(p)) return `${p}%`;
  return `${p.toFixed(1)}%`;
}

function showError(message) {
  els.errorMessage.textContent = message;
  els.errorBanner.classList.remove("hidden");
}

function hideError() {
  els.errorBanner.classList.add("hidden");
}

function setFormError(message) {
  if (!message) {
    els.formError.classList.add("hidden");
    els.formError.textContent = "";
    return;
  }
  els.formError.textContent = message;
  els.formError.classList.remove("hidden");
}

async function api(path, options = {}) {
  const res = await fetch(`${API}${path}`, {
    headers: { "Content-Type": "application/json" },
    ...options,
  });
  if (res.status === 204) return null;
  const data = await res.json().catch(() => ({}));
  if (!res.ok) {
    const err = new Error(extractError(data) || `Request failed (${res.status})`);
    err.status = res.status;
    err.data = data;
    throw err;
  }
  return data;
}

function extractError(data) {
  if (!data) return null;
  if (typeof data.detail === "string") return data.detail;
  if (Array.isArray(data.detail)) {
    return data.detail
      .map((d) => {
        const field = Array.isArray(d.loc) ? d.loc.filter((p) => p !== "body").join(".") : "";
        return field ? `${field}: ${d.msg}` : d.msg;
      })
      .join("; ");
  }
  return null;
}

function renderEmpty() {
  els.empty.classList.remove("hidden");
  els.grid.classList.add("hidden");
}

function renderGrid(topics) {
  els.empty.classList.add("hidden");
  els.grid.innerHTML = "";
  for (const t of topics) {
    const node = els.template.content.firstElementChild.cloneNode(true);
    node.dataset.id = String(t.id);
    node.querySelector(".topic-name").textContent = t.name;
    const badge = node.querySelector(".topic-type-badge");
    badge.textContent = t.type === "videos" ? "Videos" : "Book";
    node.querySelector(".topic-units").textContent =
      `${t.completed_units} / ${t.total_units} ${unitWord(t.type)}`;
    node.querySelector(".topic-percent").textContent = formatPercent(t.completion_percentage);
    const fill = node.querySelector(".progress-fill");
    fill.style.width = `${Math.min(100, Math.max(0, t.completion_percentage))}%`;
    if (t.is_completed) fill.classList.add("complete");

    const remaining = node.querySelector(".topic-remaining");
    const paceLine = node.querySelector(".topic-pace");
    const estimateLine = node.querySelector(".topic-estimate");
    const completedBadge = node.querySelector(".topic-completed-badge");

    remaining.textContent = `Remaining: ${t.remaining_units} ${unitWord(t.type)}`;
    if (t.is_completed) {
      completedBadge.classList.remove("hidden");
      remaining.classList.add("hidden");
    } else if (t.pace_units != null && t.pace_period != null) {
      const unit = t.pace_units === 1 ? unitSingular(t.type) : unitWord(t.type);
      paceLine.textContent = `Pace: ${t.pace_units} ${unit} per ${t.pace_period}`;
      paceLine.classList.remove("hidden");
      if (t.estimated_days_to_finish != null) {
        const periods = formatPeriods(t.estimated_periods_to_finish);
        const periodWord = t.estimated_periods_to_finish === 1 ? t.pace_period : `${t.pace_period}s`;
        estimateLine.innerHTML =
          `Est. finish: <strong>~${t.estimated_days_to_finish} days</strong> (${periods} ${periodWord})`;
        estimateLine.classList.remove("hidden");
      }
    } else {
      paceLine.textContent = "No pace set";
      paceLine.classList.remove("hidden");
    }

    node.querySelector(".topic-updated").textContent = `Updated ${formatRelative(t.updated_at)}`;
    node.querySelector(".topic-edit").addEventListener("click", () => openModal(t));
    node.querySelector(".topic-delete").addEventListener("click", () => onDelete(t));
    els.grid.appendChild(node);
  }
  els.grid.classList.remove("hidden");
}

async function refresh() {
  hideError();
  try {
    const topics = await api("");
    els.loading.classList.add("hidden");
    if (topics.length === 0) renderEmpty();
    else renderGrid(topics);
  } catch (e) {
    els.loading.classList.add("hidden");
    showError(`Could not load topics: ${e.message}`);
  }
}

function updateLabels() {
  const word = unitWord(els.typeInput.value);
  const singular = unitSingular(els.typeInput.value);
  els.totalLabel.textContent = `Total ${word}`;
  els.completedLabel.textContent = `Completed ${word}`;
  els.paceUnitsLabel.textContent = `${singular[0].toUpperCase()}${singular.slice(1)}s per period`;
}

function openModal(topic) {
  setFormError(null);
  if (topic) {
    editingId = topic.id;
    els.modalTitle.textContent = "Edit Topic";
    els.nameInput.value = topic.name;
    els.typeInput.value = topic.type;
    els.totalInput.value = topic.total_units;
    els.completedInput.value = topic.completed_units;
    els.paceUnitsInput.value = topic.pace_units ?? "";
    els.pacePeriodInput.value = topic.pace_period ?? "";
  } else {
    editingId = null;
    els.modalTitle.textContent = "Add Topic";
    els.form.reset();
    els.typeInput.value = "book";
    els.totalInput.value = "";
    els.completedInput.value = "";
    els.paceUnitsInput.value = "";
    els.pacePeriodInput.value = "";
  }
  updateLabels();
  els.modal.classList.remove("hidden");
  els.nameInput.focus();
}

function closeModal() {
  els.modal.classList.add("hidden");
  editingId = null;
  setFormError(null);
}

async function onSubmit(e) {
  e.preventDefault();
  setFormError(null);

  const name = els.nameInput.value.trim();
  const type = els.typeInput.value;
  const total = Number(els.totalInput.value);
  const completed = Number(els.completedInput.value);

  if (!name) return setFormError("Subject name is required.");
  if (!Number.isInteger(total) || total < 0) return setFormError("Total must be a non-negative whole number.");
  if (!Number.isInteger(completed) || completed < 0) return setFormError("Completed must be a non-negative whole number.");
  if (completed > total) return setFormError("Completed cannot exceed total.");

  const paceUnitsRaw = els.paceUnitsInput.value.trim();
  const pacePeriodRaw = els.pacePeriodInput.value;
  let paceUnits = null;
  let pacePeriod = null;
  if (paceUnitsRaw !== "" || pacePeriodRaw !== "") {
    if (paceUnitsRaw === "" || pacePeriodRaw === "") {
      return setFormError("Set both pace amount and period, or leave both blank.");
    }
    paceUnits = Number(paceUnitsRaw);
    if (!Number.isInteger(paceUnits) || paceUnits <= 0) {
      return setFormError("Pace must be a whole number greater than zero.");
    }
    pacePeriod = pacePeriodRaw;
  }

  const payload = {
    name,
    type,
    total_units: total,
    completed_units: completed,
    pace_units: paceUnits,
    pace_period: pacePeriod,
  };

  els.saveBtn.disabled = true;
  try {
    if (editingId === null) {
      await api("", { method: "POST", body: JSON.stringify(payload) });
    } else {
      await api(`/${editingId}`, { method: "PUT", body: JSON.stringify(payload) });
    }
    closeModal();
    await refresh();
  } catch (err) {
    setFormError(err.message);
  } finally {
    els.saveBtn.disabled = false;
  }
}

async function onDelete(topic) {
  if (!confirm(`Delete "${topic.name}"? This cannot be undone.`)) return;
  try {
    await api(`/${topic.id}`, { method: "DELETE" });
    await refresh();
  } catch (err) {
    showError(`Could not delete topic: ${err.message}`);
  }
}

function bindEvents() {
  els.addBtn.addEventListener("click", () => openModal(null));
  els.typeInput.addEventListener("change", updateLabels);
  els.form.addEventListener("submit", onSubmit);
  els.errorDismiss.addEventListener("click", hideError);
  document.querySelectorAll("[data-modal-close]").forEach((el) => {
    el.addEventListener("click", closeModal);
  });
  document.addEventListener("keydown", (e) => {
    if (e.key === "Escape" && !els.modal.classList.contains("hidden")) closeModal();
  });
}

bindEvents();
refresh();
