package main

import "fmt"

func main() {
	// a pointer is simply a variable whose contents are the address where another variable is stored
	x := 10
	y := true
	// the & is the address operator. It precedes a value type and returns the address of the memory where it's stored
	pointerX := &x
	pointerY := &y

	// the * is the indirection operator. It precedes a variable of pointer type and returns the pointed-to value. This is called dereferencing
	fmt.Println(pointerX, *pointerX)
	fmt.Println(pointerY, *pointerY)
}