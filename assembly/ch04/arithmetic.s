.globl _start
.section .text
_start:
	# perform various arithmetic functions
	movq $3, %rdi # move value 3 into %rdi
	movq %rdi, %rax # move %rdi's value into %rax
	addq %rdi, %rax # 3 + 3 = 6, 6 is now saved into %rax
	mulq %rdi # 3 * 6 = 18, 18 is now saved into %rax
	movq $2, %rdi #move value 2 into %rdi
	addq %rdi, %rax # 2 + 18 = 20, 20 is now saved in %rax
	movq $4, %rdi # move value 4 into %rdi
	mulq %rdi # 4 * 20 = 80, 80 is now saved in %rax
	movq %rax, %rdi # move the content of %rax into %rdi
	movq $60, %rax # set the exit system call number
	syscall #perform the system call
