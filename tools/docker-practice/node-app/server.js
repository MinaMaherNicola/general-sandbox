const app = require('express')();
const { createClient } = require('redis');

const client = createClient({
	url: 'redis://redis-server:6379'
});

client.on('error', err => console.log('Redis Client Error', err));
client.on('connect', () => console.log('Connected to Redis'));

client.connect();

app.get('/', async (req, res) => {
	try {
		let visits = await client.get('visits');
		if (visits === null) {
			visits = 0;
		}
		visits = parseInt(visits, 10) || 0;
		await client.set('visits', visits + 1);
		res.send('Number of visits is ' + visits);
	} catch (err) {
		console.error('Error interacting with Redis', err);
		res.status(500).send('Error interacting with Redis');
	}
});

app.listen(3000, () => {
	console.log('Server is running on port 3000');
});
