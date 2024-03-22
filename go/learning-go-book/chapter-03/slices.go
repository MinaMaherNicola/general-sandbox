package main

import (
	"fmt"
	"slices"
)

func main() {
	var x = []int {10, 20, 30}

	fmt.Println(x)

	var y = []int {10, 20, 30}

	// this will compare two slices in term of length and elements
	fmt.Println(slices.Equal(x, y))

	var z = []int {20, 30, 40}
	fmt.Println(slices.Equal(x, z))

	// you can append to the slice (dynamic array/list)
	y = append(y, 10)
	y = append(y, z...)
	fmt.Println(y)
}