; Description: demonstrating the use of Linux INT 80H syscalls to display text.
; Build using these commands:
; 	nasm -f elf -g -F stabs eatsyscall.asm
; 	ld -o eatsyscall eatsyscall.o

SECTION .data		; section containing initialized data
EatMsg: db "Eat at Joe's",10
EatLen: equ $-EatMsg

SECTION .bss		; Section containing uninitialized data
SECTION .text		; Section containing code
global _start		; Linker needs this to find the entry point!
_start:
	nop		; this no-op keeps gdp happy
	mov eax,4	; specify sys_write syscall
	mov ebx,1	; specify file descriptor 1: standard output
	mov ecx,EatMsg	; pass offset of the message
	mov edx,EatLen	; pass the length of the message
	int 80H		; make syscall to output the text to stoud
	mov eax,1	; specify exit syscall
	mov ebx,0	; return a code of zero
	int 80H		; make syscall to terminate the program
