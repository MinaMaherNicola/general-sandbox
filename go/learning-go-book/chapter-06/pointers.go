package main

import "fmt"

func main() {
	x := 10
	pointToX := &x

	fmt.Println(pointToX)
	fmt.Println(*pointToX)

	*pointToX = 20

	fmt.Println(pointToX)
	fmt.Println(*pointToX)
	fmt.Println(x)
}