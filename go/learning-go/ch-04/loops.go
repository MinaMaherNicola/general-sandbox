package main

import "fmt"

func main() {
	for i := 0; i < 10; i++ {
		fmt.Print(i, " ")
	}
	fmt.Println()
	
	i := 0
	for i < 10 {
		fmt.Print(i, " ")
		i++
	}
	fmt.Println()

	// infinite loop
	// for {
	// 	fmt.Println("Hello!")
	// }

	// for-range loops
	nums := []int {1, 2, 3, 4, 5, 6}
	for i, v := range nums {
		fmt.Println(i, v)
	}

	uniqueNames := map[string]bool {"Mina": true, "Maher": true, "Nicola": true}
	for k := range uniqueNames {
		fmt.Println(k)
	}
}