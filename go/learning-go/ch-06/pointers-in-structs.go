package main

func main() {
	// this wont work
	p := Person {
		"Mina",
		"Maher",
		"Nicola",
	}
	name := "Maher"

	// this will work
	p2 := Person {
		"Mina",
		&name,
		"Nicola",
	}
}

type Person struct {
	FirstName  string
	MiddleName *string
	LastName   string
}