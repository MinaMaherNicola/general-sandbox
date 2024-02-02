package main

import "fmt"

func main() {
	myFunc(MyFuncOpts{
		FirstName: "Mina",
		LastName: "Maher",
	})
}

type MyFuncOpts struct {
	FirstName string
	LastName string
	Age int
}

func myFunc(opt MyFuncOpts) {
	fmt.Println(opt.FirstName, opt.LastName, opt.Age)
}