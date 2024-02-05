package main

import "fmt"

func main() {
	var x *int = nil
	var y interface{}
	fmt.Println(y == nil)
	var z *interface{}
	y = x
	fmt.Println(y == nil)
	fmt.Println(z == nil)
}