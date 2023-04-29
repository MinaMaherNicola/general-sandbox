type Admin = {
	name: string;
	privileges: string[];
};

// intersecting types
// allows you to combine two types together
type Employee = {
	name: string;
	startDate: Date;
};

type ElevatedEmployee = Admin & Employee;

const e1: ElevatedEmployee = {
	name: 'Max',
	privileges: ['Admin'],
	startDate: new Date()
};

// type gaurds
function printEmployeeInformation(emp: ElevatedEmployee) {
	console.log(`Name: ${emp.name}`);
	// allows you to check if a property exists on an object
	if ('privileges' in emp) {
		console.log(`Privileges: ${emp.privileges}`);
	}
	if (`startDate` in emp) {
		console.log(`Start Date: ${emp.startDate.toISOString()}`);
	}
}

printEmployeeInformation(e1);

class Car {
	drive() {
		console.log('Driving a car');
	}
}

class Truck {
	drive() {
		console.log('driving a truck');
	}

	loadCargo(amount: number) {
		console.log('Loading cargo ' + amount);
	}
}

type Vehicle = Car | Truck;

const v1 = new Car();
const v2 = new Truck();

function useVehicle(vehicle: Vehicle) {
	vehicle.drive();
	// more elegent way of type gaurding
	if (vehicle instanceof Truck) {
		vehicle.loadCargo(10);
	}
}

useVehicle(v1);
useVehicle(v2);

// Discriminated union
// discriminated union is having 1 property in each type that describes that type for you
interface Bird {
	type: 'bird';
	flyingSpeed: number;
}

interface Horse {
	type: 'horse';
	runningSpeed: number;
}

type Animal = Bird | Horse;

function moveAnimal(animal: Animal) {
	if (animal.type === 'bird') console.log(`Movingg with speed: ${animal.flyingSpeed}`);
	if (animal.type === 'horse') console.log(`Movingg with speed: ${animal.runningSpeed}`);
}

moveAnimal({ type: 'bird', flyingSpeed: 10 });
moveAnimal({ type: 'horse', runningSpeed: 50 });

// type casting
const paragraph = document.getElementById('message-input') as HTMLInputElement;
paragraph.value = 'Hello World!';

// index properties
interface ErrorContainer {
	// this means that I don't know how many properties should be added to this interface, but for each property, the property should have a name (string) and a value (string)
	[prop: string]: string;
}

const errorBag: ErrorContainer = {
	email: 'Not a valid email'
};

// methods overloads
function add(a: number, b: number): number;
function add(a: string, b: string): string;
function add(a: string | number, b: string | number) {
	if (typeof a === 'string' || typeof b === 'string') {
		return a.toString() + b.toString();
	}
	return a + b;
}

const result = add('Mina', 'Maher');
result.split(' ');

// optional chaining
const fetchedUsers = {
	name: 'Mina',
	age: 23
};

// console.log(fetchedUsers?.job?.title);
