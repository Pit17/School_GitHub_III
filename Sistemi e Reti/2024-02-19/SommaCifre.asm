;Pietro Malzone 3H 19/02/2024
name "es_SommaCifre"

.model small

.data
    n1 dw 3456   
    somma dw ?
    numero dw ? 
    divisore dw 10   
    giri dw 0 
    conta dw 0
    
.code
.startup       
    mov ax,n1
    GIRO:   
    mov dx,0
    div divisore 
    add somma,dx
    cmp ax,0
    jnz GIRO   
    mov dx,0
    mov ax,somma   
    
    ROUND:   
    mov dx,0
    div divisore  
    push dx 
    inc giri
    cmp ax,0
    jnz ROUND
    mov bx,0000h
    doPOP:
    mov ax,0
    pop cx 
    mov AX, @DATA
    mov DS, AX    
    add cx,48
    mov dx,cx
    mov ah,2
    int 21h
    inc bx
    cmp bx,giri
    jl doPOP     
.exit
end
   



