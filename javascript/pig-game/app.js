const prompt = require('prompt-sync')();

console.log('Enter e to exit at anytime.');

const scores = { 0: 0, 1: 0 };
let turn = true;

while (scores[0] < 100 && scores[1] < 100) {
	console.log(`\nPlayer-0: ${scores[0]} ||||| Player-1: ${scores[1]}\n`);
	let rollingScore = 0;
	while (true) {
		console.log('\n-------------');
		console.log(
			`Player-${turn ? 0 : 1} Your rolling score is ${rollingScore}, your total score is ${
				scores[turn ? 0 : 1]
			}. Do you want to roll? Y/N `
		);
		const input = prompt();
		if (input === 'e') {
			process.exit(1);
		}
		if (input.toLowerCase() === 'n') {
			scores[turn ? 0 : 1] += rollingScore;
			turn = !turn;
			break;
		}
		if (input.toLowerCase() === 'y') {
			const die = Math.trunc(Math.random() * 6) + 1;
			console.log(`You rolled ${die}`);
			if (die === 1) {
				turn = !turn;
				break;
			}
			rollingScore += die;
		}
		console.log('-------------\n');
	}
}
console.log(`Player-0: ${scores[0]} ||||| Player-1: ${scores[1]}`);
console.log(scores[0] >= 10 ? 'Player-0 Won!' : 'Player-1 Won!');
