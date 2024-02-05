package main

import "fmt"

func main() {
	var x any
	y := 15
	x = y

	i := x.(int)

	fmt.Println(i)

	z, ok := x.(string)

	if !ok {
		fmt.Println("Could not assert to string")
		return;
	}
	fmt.Println(z)

	// type assertion vs type conversion
		// type conversion is done in compile time, if the conversion is not logical, the compiler won't compile your code
		// type assertion is done in runtime, and if you are not using the comma ok idom it might fail and cause a panic
}