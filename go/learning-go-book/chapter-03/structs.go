package main

import "fmt"

type Person struct {
	name string
	age int
}

func main() {
	mina := Person {
		"Mina",
		24,
	}
	maher := Person {
		name: "Maher",
		age: 67,
	}

	mina.age = 25

	fmt.Println(mina)
	fmt.Println(maher)
}