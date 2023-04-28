class Department {
	private readonly employees: string[] = [];

	// constructor(name: string) {
	// 	this.name = name;
	// }

	// shorcut for constructing fields and properties
	constructor(private name: string, public readonly id: number) {}

	describe = () => {
		console.log(`this is the ${this.name} department`);
	};

	// this means that the this keyword anywhere used in this method should only be accessed within a Department object
	describe2(this: Department) {
		console.log(`this is the ${this.name} department`);
	}

	addEmployee(employee: string) {
		this.employees.push(employee);
	}

	printEmployeesInformation() {
		console.log(this.employees.length);
		console.log(this.employees);
	}
}

class ITDepartment extends Department {
	constructor(public readonly id: number, private readonly languages: string[]) {
		super('IT', id);
	}

	addLanguage(language: string) {
		this.languages.push(language);
	}
}

class Animal {
	static group: number = 20;
	private type?: string;
	constructor() {
		this.type = undefined;
	}

	get getType() {
		return this.type;
	}

	set setType(value: string) {
		this.type = value;
	}

	static makeNoise() {
		return 'Raawwr';
	}
}

const dep = new Department('Development', 1);
console.log(dep);
dep.describe();
dep.describe2();

dep.addEmployee('Mina');
dep.addEmployee('Maher');
dep.printEmployeesInformation();

console.log('-------------------------');

const itDep = new ITDepartment(2, ['C#', 'TypeScript']);
itDep.addLanguage('JavaScript');

console.log(itDep);

const animal = new Animal();

animal.setType = 'K9';
console.log(animal.getType);
console.log(Animal.makeNoise());
console.log(Animal.group);

// ----------------- abstract classes
abstract class Bird {
	protected name: string;

	constructor(name: string) {
		this.name = name;
	}

	get getName() {
		return this.name;
	}

	set setName(value: string) {
		this.name = value;
	}

	public abstract fly(): string;
}

class Eagle extends Bird {
	constructor() {
		super('Eagle');
	}
	public fly(): string {
		return `${this.name} is flying right now`;
	}
}

const eagle = new Eagle();
console.log(eagle.fly());
