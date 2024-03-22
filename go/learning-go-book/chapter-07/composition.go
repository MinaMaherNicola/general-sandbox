package main

import "fmt"

func main() {
	mina := Employee {
		Id: 1,
		Name: "Mina",
	}

	bob := Manager {
		Employee: Employee{
			Id: 2,
			Name: "Bob",
		},
		Reports: append(make([]Employee, 0, 2), Employee{
			Id: 3,
			Name: "Ahmed",
		}),
	}
	bob.Reports = append(bob.Reports, mina)
	bob.printEmployees()
}

type Employee struct {
	Id uint
	Name string
}

func (e Employee) Describe() string {
	return fmt.Sprintf("Name: %s, Id: %d", e.Name, e.Id)
}

type Manager struct {
	Employee
	Reports []Employee
}

func (m Manager) printEmployees() {
	for _, v := range m.Reports {
		fmt.Println(v.Describe())
	}
}