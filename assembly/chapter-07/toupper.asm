section .data
	Snippet db "Kangaroo"

section .text
	global _start
	_start:
		nop
		
		mov ebx, Snippet
		mov eax, 8

		DoMore: add byte [ebx], 32

		inc ebx
		dec eax
		jnz DoMore

		nop
