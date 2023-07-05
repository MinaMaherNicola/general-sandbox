section .data
	Msg: db "Hello World!"
section .text

	global _start

_start:
	nop					; put your experiments between the two nops
	
	; the mov instruction
	mov eax, 23H		; this means move the value 23H into eax register
	mov ebx, eax		; this means move the value of eax into the ebx register

	mov cl, bh			; this means move the most significant byte of bx into the least significant byte of cx
	mov ch, bl			; this means move the least significant byte of bx into the highest significant byte of ch
	mov eax, [ebx]	; this means move the value saved in the memory address that is in ebx register into the eax register
	mov eax, Msg		; this will not move the current value of "Msg" into the register eax, but will move the address of the value into the eax
	mov eax, [Msg]	; this will move the current value of "Msg" into the register eax
	mov [Msg], byte 'G'	; NASM doesn't keep track of the length of data, it only knows where the data started, so if you can tell NASM how many bytes of data to move like this. Here, you tell NASM that you only want to move a single byte out to memory by using the byte size specifier, other specifiers exist such as word, and dword
	; the mov instruction

	; the xchg instruction
	xchg cl, ch			; this means exchange the values of cl and ch
	; the xchg instruction

	; the add instruction
	add eax, 1h			; this will add the source value with the destination value and replace the destination value with the result
	; the add instruction

	; the dec and inc instructions
	inc eax					; this will increment the value inside of eax by one
	dec eax					; this will decrement the value inside of eax by one
	; the dec and inc instructions



	; labels
	mov eax, 5
	DecrementEax: dec eax		; this is now a label that you can jump to
	jnz DecrementEax				; the jnz is a "jump of zero" conditional jump, which checks if the ZF is set or not, if it is set nothing happens, if not it will jump to some label in the code
	; labels
	nop					; put your experiments between the two nops

section .bss
