package main

import "fmt"

func main() {
	p := Person {
		"Mina",
		24,
	}
	fmt.Println(p.name, p.age)
	modifyPerson(p) // this will fail
	fmt.Println(p.name, p.age)

	var nums []int = []int {1, 2, 3, 4}
	fmt.Println(nums)
	modifySlice(nums) // this will work
	fmt.Println(nums)

	names := map[int]string {
		0: "Mina",
		1: "Maher",
	}
	fmt.Println(names)
	modifyMap(names) // this will work
	fmt.Println(names)

}

type Person struct {
	name string
	age int
}

func modifyPerson(p Person) {
	p.name = "Maher"
	p.age = 65
}

func modifySlice(s []int) {
	s[0] = 4
}

func modifyMap(m map[int]string) {
	m[0] = "Nicola"
}