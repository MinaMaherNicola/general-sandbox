package main

import "fmt"

func main() {
	// Go deals with length slices/maps by assigning a capacity to the slice/map
	// For example, if the capacity and length of a slice is 3 items, and you tried to add a 4th item
	// Go will try to create a new slice in memory, then copy your items, and add the last item that you've just added
	// and then it will collect the garbage of the previous slice. To ensure this won't happen again, Go will double the 
	// capacity of the newly created slice. You can control your capacity in Go.
	var slice = []int {1, 2, 3 ,4}

	fmt.Println(cap(slice))
	slice = append(slice, 1)
	fmt.Println(len(slice), cap(slice))

	// to control the capacity:
	x := make([]int, 10)

	fmt.Println(len(x), cap(x))
	
	// to control the capacity and the length:
	y := make([]int, 0, 10)
	fmt.Println(len(y), cap(y))
}