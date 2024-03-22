package main

import "fmt"

func main() {
	c := Client{
		L: LogicProvider{},
	}

	c.Program()
}

type LogicProvider struct {}

func (lp LogicProvider) Process(data string) {
	fmt.Println("Processing the following data:", data)
}

type Logic interface {
	Process(data string)
}

type Client struct {
	L Logic
}

func (c Client) Program() {
	c.L.Process("'This is business data'")
}