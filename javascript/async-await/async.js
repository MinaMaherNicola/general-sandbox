const getData = async () => {
	const data = await fetch('https://jsonplaceholder.typicode.com/posts/1');
	console.log(await data.json());
};

getData();
console.log('Sync code');
