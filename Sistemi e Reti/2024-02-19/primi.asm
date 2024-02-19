;Pietro Malzone 3H 12/02/2024
name "es_primi"

.model small

.data
    n dw 11    
    risultato db ?  
    partenza dw ?
    conta dw ?
.code
.startup      
    mov ax,n
    mov partenza,ax
    CONTATORE:
    mov ax,n
    mov dx,0
    dec partenza
    div partenza
    cmp dx,0
    jz OUTPUT
    cmp partenza,2
    jz Risultato1
    jmp CONTATORE
    
    Risultato1:
    mov risultato,1
    OUTPUT:
    mov ax,0
    mov dx,0
    mov ax,@DATA
    mov ds,ax
    add risultato,48
    mov dl,risultato 
    mov ah,2
    int 21h

      
.exit
end
   

