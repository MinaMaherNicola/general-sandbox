class SingleNode<T> {
	private readonly data: T;
	private next?: SingleNode<T>;

	constructor(data: T, next?: SingleNode<T>) {
		this.data = data;
		this.next = next;
	}
}
const node: SingleNode<number> = new SingleNode<number>(10);

console.log(node);

function merge<T extends object, U extends object>(a: T, b: U) {
	return Object.assign(a, b);
}

const result = merge({ name: 'Mina' }, { age: 23 });
console.log(result);

interface HasLength {
	length: number;
}

const countAndDescribe = <T extends HasLength>(a: T) => {
	return `${a} has ${a.length} elements`;
};

console.log(countAndDescribe('a'));
console.log(countAndDescribe([1, 2, 3]));

const extractAndConvert = <T extends object, U extends keyof T>(obj: T, key: U) => {
	return obj[key];
};

console.log(extractAndConvert({ a: 'J' }, 'a'));
