package main

import (
	"fmt"
	"sync"
	"time"
)

func main() {
	greenLights := sync.NewCond(&sync.Mutex{})

	wg := sync.WaitGroup{}
	// turn the lights green
	wg.Add(1)
	go func() {
		defer wg.Done()
		time.Sleep(time.Second * 4)
		greenLights.L.Lock()
		defer greenLights.L.Unlock()

		greenLights.Signal()
	}()

	for i := 1; i < 6; i++ {
		go func(id int) {
			defer wg.Done()
			greenLights.L.Lock()
			fmt.Printf("Car %d arrived at red light\n", id)
			greenLights.Wait()
			fmt.Printf("Car %d moved at green light\n", id)
			greenLights.L.Unlock()
		}(i)
	}
	wg.Wait()
}