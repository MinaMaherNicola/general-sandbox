package main

import (
	"errors"
	"fmt"
)

func main() {
	fmt.Println(divide[int](10, 2))
	fmt.Println(divide[int](10, 0))
}

type Integer interface {
	int | int8 | int16 | int32 | int64 | uint | uint8 | uint16 | uint32 | uint64 | uintptr
}

func divide[T Integer](n1 T, n2 T) (T, error) {
	if n2 == 0 {
		return 0, errors.New("Cannot divide by 0")
	}
	return n1 / n2, nil
}