package main

import (
	"fmt"
	"sync"
)

var count int = 0
func inc() {
	count++
}
func dec() {
	count--
}
func main() {
	fmt.Println(count)
	
	func() {
		once := sync.Once{}
		once.Do(inc)
	}()

	fmt.Println(count)
	func() {
		once := sync.Once{}
		once.Do(dec)
	}()

	fmt.Println(count)
}