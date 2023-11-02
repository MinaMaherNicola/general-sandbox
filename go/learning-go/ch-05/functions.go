package main

import "fmt"

func main() {
	fmt.Println(div(10, 2))

	nums := []int {1, 2, 3, 4}
	fmt.Println(addOne(nums...))
}

func div(numerator int, denominator int) int {
	if denominator == 0 {
		return 0
	}
	return numerator / denominator
}

func addOne(vals ...int) []int {
	length := len(vals)
	nums := make([]int, length, length)
	for i := 0; i < length; i++ {
		nums[i] = vals[i] + 1
	}
	return nums
}