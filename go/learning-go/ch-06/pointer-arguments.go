package main

import "fmt"

func main() {
	x := 1000
	wontChange(x)
	fmt.Println(x)
	willChange(&x)
	fmt.Println(x)
}

func willChange(x *int) {
	*x = 50
}

func wontChange(x int) {
	x = 500
}