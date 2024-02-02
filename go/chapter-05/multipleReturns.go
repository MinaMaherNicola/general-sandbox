package main

import (
	"errors"
	"fmt"
)

func main() {
	res, mes, err := divAndSayHi(10, 2)
	if err != nil {
		fmt.Println(err)
	}
	fmt.Println(res, mes)
}

func divAndSayHi(num int, denom int) (int, string, error) {
	if denom == 0 {
		return 0, "Nope", errors.New("Cannot divide by zero")
	}
	return num / denom, "Hello", nil
}