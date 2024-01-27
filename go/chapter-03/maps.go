package main

import "fmt"

func main() {
	ages := map[string]int {
		"Mina": 24,
		"Maher": 67,
	}
	fmt.Println(ages["Mina"])
	fmt.Println(ages["Test"])

	// if you know how many key-value pairs you intend to put in a map
	// but don't know the values yet, use make to create it
	jobs := make(map[string]string, 1)

	jobs["Mina"] = "Software Engineer"
	fmt.Println(jobs["Mina"])
	fmt.Println(jobs["Test"])

	// how to know if a key is in a map or not?
	v, ok := jobs["Mina"]
	fmt.Println(v, ok)
	
	v, ok = jobs["Hi"]
	fmt.Println(v, ok)

	delete(ages, "Mina")
	fmt.Println(ages)
}