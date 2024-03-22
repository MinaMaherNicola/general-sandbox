package main

import "fmt"

func main() {
	var x int = 10
	y := 10

	fmt.Println(x + y)

	number, str := 200, "Hi"

	fmt.Println(number, str)

	const z int = 20

	fmt.Println(z)

	const untypedConst = 400

	fmt.Println(untypedConst)
}