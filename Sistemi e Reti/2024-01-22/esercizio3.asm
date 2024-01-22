name 'esercizio3' ; Pietro Malzone 3H 22/01/2024    

.model small

.data
    W dw ?
    X dw 3
.code
    .startup
        mov ax,x
        mov bx,5
        mul bx
        mov w,ax
    .exit
end
