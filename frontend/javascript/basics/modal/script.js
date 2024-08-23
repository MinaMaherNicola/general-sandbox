'use strict';

const modal = document.querySelector('.modal');
const overlay = document.querySelector('.overlay');

document
	.querySelectorAll('.show-modal')
	.forEach(element => element.addEventListener('click', openModal));

overlay.addEventListener('click', closeModal);

document.querySelector('.close-modal').addEventListener('click', closeModal);

document.addEventListener('keydown', e => {
	if ((e.key === 'Escape' || e.key === 'Esc') && isModalOpen()) {
		closeModal();
	}
});

function openModal() {
	if (!isModalOpen()) {
		modal.classList.remove('hidden');
		overlay.classList.remove('hidden');
	}
}

function closeModal() {
	if (isModalOpen()) {
		modal.classList.add('hidden');
		overlay.classList.add('hidden');
	}
}

function isModalOpen() {
	return (
		!modal.classList.contains('hidden') && !overlay.classList.contains('hidden')
	);
}
