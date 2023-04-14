const wait = secs => {
	return new Promise(resolve => {
		setTimeout(() => {
			resolve(secs);
		}, secs);
	});
};

wait(1)
	.then(res => {
		console.log(`${res} seconds passed`);
		return wait(2);
	})
	.then(res => {
		console.log(`${res} seconds passed`);
		return wait(3);
	})
	.then(res => {
		console.log(`${res} seconds passed`);
		return wait(4);
	})
	.then(res => console.log(`${res} seconds passed`));
