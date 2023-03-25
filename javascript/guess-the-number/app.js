const prompt = require('prompt-sync')();

let highScore = 0;

console.log('Press e anytime to exit');

const startGame = () => {
	const randomNumber = Math.trunc(Math.random() * 20) + 1;
	let attempts = 19;
	while (attempts !== 0) {
		let input = prompt('Enter your guess: ');
		if (input === 'e') {
			process.exit(1);
		}
		if (isNaN(Number(input))) {
			console.log('Please enter a valid number: ');
			continue;
		}
		input = Number(input);

		if (input === randomNumber) {
			if (attempts > highScore) highScore = attempts;
			return true;
		}
		console.log('\n------------');
		if (input > randomNumber) {
			console.log(`Remaining attempts: ${attempts}
      high-score: ${highScore}
      Last guess was too big`);
		} else {
			console.log(`Remaining attempts: ${attempts}
      high-score: ${highScore}
      Last guess was too small`);
		}
		attempts--;
		console.log('------------\n');
	}
	return false;
};

const printSuccess = () =>
	prompt(`Win, high-score: ${highScore}. Would you like to try again? Y/N `);
const printFailure = () =>
	prompt(`Loss, high-score: ${highScore}. Would you like to try again? Y/N `);

while (true) {
	const result = startGame();
	let playAgain;

	if (result) {
		playAgain = printSuccess();
	} else {
		playAgain = printFailure();
	}

	if (playAgain === 'N') break;
}
