package main

import (
	"fmt"
	"os"
)

func main() {
	var output string
	for i := 1; i < len(os.Args); i++ {
		output += os.Args[i] + " "
	}
	fmt.Println(output)
}