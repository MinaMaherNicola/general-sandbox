package main

import "fmt"

func main() {
	x := []int {1, 2, 3, 4, 5}
	y := make([]int, 4)

	num := copy(y, x)

	fmt.Println(x, y, num)
}