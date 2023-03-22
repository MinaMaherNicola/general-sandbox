# this is a comment in assembly
.global _start
.section .text
_start:
	movq $60, %rax
	movq $3, %rdi
	syscall

