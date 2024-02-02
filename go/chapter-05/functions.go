package main

import "fmt"

func main() {
	fmt.Println(div(10, 2))
}

func div(num int, denom int) int {
	if denom == 0 {
		return 0
	}
	return num / denom
}