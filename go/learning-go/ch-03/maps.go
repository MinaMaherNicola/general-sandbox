package main

import "fmt"

func main() {
	// this is declared to be a map with string key and int value
	m := map[string]int{}

	m["hi"] = 10
	fmt.Println(m["hi"])

	data := map[string]int {
		"age": 24,
		"height": 184,
	}
	fmt.Println(data["age"])

	delete(data, "age")
	
	fmt.Println(data["age"])

	test := map[string]int{
		"hello": 1,
		"world": 0,
	}
	v, exists := test["hello"]
	fmt.Println(v, exists)
	
	v, exists = test["q"]
	fmt.Println(v, exists)
}