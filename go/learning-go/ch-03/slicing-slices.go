package main

import "fmt"

func main() {
	var x = []int{1, 2, 3, 4, 5}

	fmt.Println("x[:2]", x[:2])
	fmt.Println("x[1:3]", x[1:3])
	fmt.Println("x[:]", x[:])

	// note that slices have overlapping storage when sliced
	y := x[1:3]
	y[0] = 50
	fmt.Println("x: ", x)
}