.DEFAULT_GOAL := build

.PHONY:fmt vet build

vet: fmt
	go fmt ./...

vet: fmt
	go vet ./...

build: vet
	go build