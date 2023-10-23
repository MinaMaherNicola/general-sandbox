package main

import "fmt"

func main() {
	// if you want to create a slice that's independent of the original,
	// use the built-in copy function.
	x := []int{1, 2, 3 ,4 ,5}
	y := make([]int, 5, 5)

	numberOfCopiedElements := copy(y, x)
	fmt.Println(y, numberOfCopiedElements)
}