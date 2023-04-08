.globl _start
.section .text
_start:
	movq $0b1101, %rdi # move this binary value into %rdi
	movq $60, %rax # move the end program call into rax
	syscall
