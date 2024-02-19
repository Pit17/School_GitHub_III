;Pietro Malzone 3H 19/02/2024
name "es_SommaCompresa"

.model small

.data
    n1 dw 1   
    n2 dw 5 
    divisore dw 10   
    giri dw 0 
    conta dw 0
    somma dw ?
    giro dw ?
.code
.startup       
     mov dx,n1
     mov giro,dx
     mov ax,giro
     CICLO:
     inc giro  
     add ax,giro
     mov bx,giro
     cmp bx,n2   
     jnz CICLO
     mov somma,ax
     
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
   




