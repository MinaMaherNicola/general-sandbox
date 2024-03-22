package main

import "fmt"

func main() {
	s := Stack[int]{}

	s.Push(1)
	s.Push(2)
	s.Push(3)

	fmt.Println(s.items)

	fmt.Println(s.Pop())
	fmt.Println(s.Pop())
	fmt.Println(s.Pop())
	fmt.Println(s.Pop())
	fmt.Println(s.Pop())
}

type Stack[T any] struct {
	items []T
}


func (s *Stack[T]) Push(item T) {
	s.items = append(s.items, item)
}

func (s *Stack[T]) Pop() (T, bool) {
	sliceLength := len(s.items)
	if  sliceLength == 0 {
		var zero T
		return zero, false
	}
	output := s.items[sliceLength - 1]
	s.items = s.items[:sliceLength - 1]
	return output, true
}