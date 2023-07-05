all: sandbox toupper

sandbox: sandbox.o
	ld -m elf_i386 -o sandbox sandbox.o

sandbox.o: sandbox.asm
	nasm -f elf32 -g -F stabs sandbox.asm

toupper: toupper.o
	ld -m elf_i386 -o toupper toupper.o

toupper.o: toupper.asm
	nasm -f elf32 -g -F stabs toupper.asm
