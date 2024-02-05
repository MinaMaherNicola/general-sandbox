package main

import (
	"errors"
	"fmt"
	"log"
)

func main() {
	fmt.Println(Personal)
	fmt.Println(Spam)

	name, err := Spam.toString()
	if err != nil {
		log.Fatal(err)
	}

	fmt.Println(name)
}

type MailCategory int

const (
	Uncategorized MailCategory = iota
	Personal
	Spam
	Social
	Ads
)

func (cat MailCategory) toString() (string, error) {
	switch cat {
		case Uncategorized:
			return "Uncategorized", nil
		case Personal:
			return "Personal", nil
		case Spam:
			return "Spam", nil
		case Social:
			return "Social", nil
		case Ads:
			return "Ads", nil
		default:
			return "", errors.New("Category not found")
	}
}