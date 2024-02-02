package main

import "fmt"

func main() {
	anonymous := func(s string) {
		fmt.Println("Length of string ", s, "is ", len(s))
	}
	anonymous("Mina")
	func(i int) {
		fmt.Println("Hi from ", i)
	}(10)
}