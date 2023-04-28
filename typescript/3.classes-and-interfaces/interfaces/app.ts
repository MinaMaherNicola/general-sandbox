interface IPerson {
	name: string;
	age: number;

	greet(phrase: string): void;
}

class Person implements IPerson {
	name: string;
	age: number;
	constructor(name: string, age: number) {
		this.name = name;
		this.age = age;
	}
	greet(phrase: string): void {
		console.log(`${phrase} ${this.name}`);
	}
}
