package main

import "fmt"

func main() {
	mina := person {
		"Mina",
		23,
		"cat",
	}

	john := person {
		name: "John",
		age: 22,
		pet: "dog",
	}

	fmt.Println(mina.name)
	fmt.Println(john.name)

	// anonymous struct
	var g struct {
		name string
		age int
	}

	g.name = "Hi"
	g.age = 20	
}

type person struct {
	name string
	age int
	pet string
}