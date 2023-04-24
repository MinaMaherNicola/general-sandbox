const num: number = 20;
const str: string = 'Mina';
const bool: boolean = true;
const person = {
	name: 'Mina',
	age: 23
};
const anotherPerson: {
	name: string;
	age: number;
} = {
	name: 'Mina',
	age: 24
};
const arr: string[] = ['Sports', 'Cooking'];
const tuple: [number, string] = [10, 'A'];
enum Role {
	ADMIN, // 0
	READ_ONLY, // 1
	AUTHOR, // 2
	OWN_VALUE = 10
}

// union types
// used when you might want to use more than one type in the same context
const combine = (in1: string | number, in2: string | number) => {
	if (typeof in1 === 'number' && typeof in2 === 'number') {
		return in1 + in2;
	}
	return in1.toString() + in2.toString();
};

console.log(combine('10', '20'));
console.log(combine(10, 20));

// function return type
const getNumber = (): number => {
	return 10;
};

console.log(getNumber());

// literal types as function params
// the idea behind literal types is that the param HAVE TO BE either of the given literal types
const literalTypes = (str: 'hello' | 'hi'): string => {
	return `${str} world`;
};

console.log(literalTypes('hello'));
console.log(literalTypes('hi'));

// type aliases
type Combinable = number | string;

const combineV2 = (in1: Combinable, in2: Combinable) => {
	if (typeof in1 === 'number' && typeof in2 === 'number') {
		return in1 + in2;
	}
	return in1.toString() + in2.toString();
};

// function type
const combineValues: Function = combineV2;

combineValues(10, 20);

const fun = (num1: number, num2: number): number => {
	return num1 + num2;
};

const combineValuesV2: (a: number, b: number) => number = fun;

console.log(combineValuesV2(10, 20));

// callback functions
const callback = (a: number, b: number, c: (result: number) => void) => {
	c(a + b);
};

callback(1, 2, result => console.log(result));
