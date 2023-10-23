package main

import "fmt"

func main() {
	var x = []int {1, 2, 3 ,4}
	fmt.Println(x)

	x = append(x, 5)
	fmt.Println(x)
	
	y := []int {6, 7, 8}
	x = append(x, y...)
	fmt.Println(x)
	fmt.Println(len(x), cap(x))
}