package main

import "fmt"

func main() {
	d := Dog{}
	c := Cat{}

	AnimalSounds(d)
	AnimalSounds(c)
}

func AnimalSounds(s Speaker) {
	s.Speak()
}

type Speaker interface {
	Speak()
}

type Dog struct{}

func (d Dog) Speak() {
	fmt.Println("Woof")
}

type Cat struct{}

func (c Cat) Speak() {
	fmt.Println("Meow")
}
