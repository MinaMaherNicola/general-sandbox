package main

import "fmt"

func main() {
	var mina Person = Person{
		FirstName: "Mina",
		LastName: "Maher",
		Age: 24,
	}
	fmt.Println(mina.toString())
	mina.birthday()
	fmt.Println(mina.toString())
	wontUpdate(mina)
	fmt.Println(mina.toString())
	update(&mina)
	fmt.Println(mina.toString())
}

type Person struct {
	FirstName string
	LastName string
	Age int
}

func (p Person) toString() string {
	return fmt.Sprintf("%s %s, age: %d", p.FirstName, p.LastName, p.Age)
}

func (p *Person) birthday() {
	p.Age++;
}

func wontUpdate(p Person) {
	p.birthday()
}

func update(p *Person) {
	p.birthday()
}