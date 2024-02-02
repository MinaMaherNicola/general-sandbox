package main

import (
	"fmt"
	"io"
	"log"
	"os"
)

func main() {
	file, err := os.Open("test.txt")
	if err != nil {
		log.Fatal(err)
	}
	defer file.Close()

	data := make([]byte, 100, 100) // creating a slice with length of 100 and capacity of 100 as a buffer
	for {
		count, err := file.Read(data)
		if err != nil {
			if err != io.EOF {
				log.Fatal(err)
			}
			break
		}
		fmt.Println(string(data[:count]))
	}
}