package internal

import "github.com/shopspring/decimal"

func GetTaxes() decimal.Decimal {
	tax, _ := decimal.NewFromString("0.14")
	return tax
}