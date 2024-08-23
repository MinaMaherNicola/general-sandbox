'use strict';

let randomNumber = generateRandomNumber();
let score = 20;
let highScore = 0;
let won = false;
document.querySelector('.btn.again').addEventListener('click', reset);

document.querySelector('.btn.check').addEventListener('click', () => {
	if (won) {
		return;
	}

	if (score === 0) {
		setMessageElement('Game Over!');
		return;
	}

	const guessVal = Number(document.querySelector('.guess').value);

	if (!guessVal) {
		setMessageElement('No number!');
		return;
	}

	if (guessVal > randomNumber) {
		setMessageElement('Too high');
		decreaseScore();
		return;
	}

	if (guessVal < randomNumber) {
		setMessageElement('Too low');
		decreaseScore();
		return;
	}

	if (guessVal === randomNumber) {
		setMessageElement('Correct Number!');
		won = true;
		document.body.style.backgroundColor = '#60b347';
		if (highScore < score) {
			highScore = score;
			document.querySelector('.highscore').textContent = highScore;
		}
	}
});

function generateRandomNumber() {
	return Math.floor(Math.random() * 20) + 1;
}

function setMessageElement(message) {
	document.querySelector('.message').textContent = message;
}

function reset() {
	document.body.style.backgroundColor = '#222';
	randomNumber = generateRandomNumber();
	score = 20;
	setMessageElement('Start guessing...');
	document.querySelector('.score').textContent = score;
	won = false;
}

function decreaseScore() {
	score--;
	document.querySelector('.score').textContent = score;
}
