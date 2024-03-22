package main

import "fmt"

type funcUsingType func(string) int

func main() {
	var myFuncVar func(string) int
	myFuncVar = f1
	var fn funcUsingType = f1
	result := myFuncVar("Mina")
	result2 := fn("Mina")
	fmt.Println(result)
	fmt.Println(result2)
}


func f1(a string) int {
	return len(a)
}