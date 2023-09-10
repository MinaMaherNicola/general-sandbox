package main

import (
	"fmt"
	"io/ioutil"
	"net/http"
	"os"
)

func main() {
	var url string = "https://jsonplaceholder.typicode.com/posts/1"
	response, err := http.Get(url)
	if err != nil {
		fmt.Println(os.Stderr)
		os.Exit(1)
	}
	b, err := ioutil.ReadAll(response.Body)
	response.Body.Close()
	if err != nil {
		fmt.Println(os.Stderr)
		os.Exit(1)
	}
	fmt.Printf("%s", b)
}