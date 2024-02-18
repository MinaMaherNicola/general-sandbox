package main

import (
	"fmt"
	"modules-packages/math"
	moneypackage "modules-packages/money-package"

	"github.com/shopspring/decimal"
)

func main() {
	fmt.Println(math.Double(10))

	price, _ := decimal.NewFromString("0.2")
	addingVal, _ := decimal.NewFromString("0.1")

	fmt.Println(price.Add(addingVal))

	var x float64 = 0.1
	var y float64 = 0.2
	fmt.Println(x + y)

	fmt.Println("---------------------------")

	amount, _ := decimal.NewFromString("200.99")

	invoice := moneypackage.Invoice{
		Amount: amount,
	}

	fmt.Println("Before taxes: ", invoice.Amount)
	invoice.CalculateTax()
	fmt.Println("After taxes: ", invoice.Amount)
}