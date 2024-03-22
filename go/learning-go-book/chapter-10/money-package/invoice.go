package moneypackage

import (
	"modules-packages/money-package/internal"

	"github.com/shopspring/decimal"
)

type Invoice struct {
	Amount decimal.Decimal
}

func (i *Invoice) CalculateTax() {
	i.Amount = i.Amount.Add(internal.GetTaxes())
}