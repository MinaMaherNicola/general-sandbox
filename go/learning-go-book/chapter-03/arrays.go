package main

import "fmt"

func main() {
	var x[3]int
	x[0] = 1
	x[1] = 2
	x[2] = 3
	fmt.Println(x)

	var y = [3]int{10, 20, 30}
	fmt.Println(y)

	// sparse array (an array where most elements are set to their zero value)
	var z = [5]int {1, 4: 6}
	fmt.Println(z)

	var arrayLiteral = [...]int {10, 20}
	fmt.Println(arrayLiteral)

	// you can use the == operator to compare between two arrays
	// arrays are equal if they are the same length and contain equal values
	var arr1 = [3]int {1, 2, 3}
	fmt.Println(arr1 == x)
	fmt.Println(arr1 == y)

	// you can get the length on an array using the len() function
	fmt.Println(len(x))
}