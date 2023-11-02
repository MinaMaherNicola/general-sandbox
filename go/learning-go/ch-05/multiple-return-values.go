package main

import (
	"errors"
	"fmt"
	"os"
)

func main() {
	result, remainder, err := divAndRemainder(15, 2)
	if (err != nil) {
		fmt.Println("Something went wrong!")
		os.Exit(1)
	}
	fmt.Println("Result:", result, "Remainder:", remainder)
}

func divAndRemainder(numerator int, denominator int) (result int, remainder int, err error) {
	if denominator == 0 {
		return 0, 0, errors.New("Cannot divide by zero")
	}
	return numerator / denominator, numerator % denominator, nil
}