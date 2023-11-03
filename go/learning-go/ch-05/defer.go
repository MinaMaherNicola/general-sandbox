package main

import "fmt"

func main() {
	// In Go, the defer keyword is used to schedule a function call to be executed after the surrounding function returns. 
	defer fmt.Println("World!")
	fmt.Print("Hello ")
}