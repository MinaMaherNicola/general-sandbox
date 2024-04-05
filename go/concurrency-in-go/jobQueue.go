package main

import (
	"fmt"
	"sync"
	"time"
)

func main() {
	queue := NewQueue()
	for i := 0; i < 5; i++ {
		go func(workerId int) {
			job := queue.GetJob()
			fmt.Printf("Worker %d processing job: %s\n", workerId, job.Description)
		}(i)
	}

	jobs := []Job{{"First Job"}, {"Second Job"}, {"Third Job"}, }

	for _, job := range jobs {
		queue.AddJob(job)
		time.Sleep(time.Second * 1)
	}

	time.Sleep(time.Second)
}

type Job struct {
	Description string
}

type JobQueue struct {
	Cond sync.Cond
	Jobs []Job
}

func NewQueue() *JobQueue {
	q := &JobQueue{}
	q.Cond = *sync.NewCond(&sync.Mutex{})
	return q
}

func (q *JobQueue) AddJob(j Job) {
	q.Cond.L.Lock()
	defer q.Cond.L.Unlock()
	q.Jobs = append(q.Jobs, j)
	q.Cond.Signal()
}

func (q *JobQueue) GetJob() *Job {
	q.Cond.L.Lock()
	defer q.Cond.L.Unlock()

	for len(q.Jobs) == 0 {
		q.Cond.Wait()
	}

	j := q.Jobs[0]
	q.Jobs = q.Jobs[1:]
	return &j
}