section .data

section .text
	global _start
	_start:
		nop
		mov eax, 5
		InfiniteLoop: dec eax
		jmp InfiniteLoop
		nop
