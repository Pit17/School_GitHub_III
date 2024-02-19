;Pietro Malzone 3H 12/02/2024
name "es_confronti"

.model small

.data
    n1 db 7   
    n2 db 6
    stringa1 db 'n1 = n2$'
    stringa2 db 'n1 > n2$'
    stringa3 db 'n1 < n2$' 
    
.code
.startup      
    mov cl,n1
    mov al,n2
    sub cl,al      
    jz C
    js cl ABBA 
    jns cl ABBO  
 
    ABBO:  
    mov bl,1 
    jmp A
    ABBA:
    mov bl,-1
    jmp B
  


    C:
    mov bl,0  
	A:   
    B:    
    mov AX, @DATA
    mov DS, AX
    
    cmp bl,0             
    jz uguale  
    
    cmp bl,1
    jz maggiore 
    
    cmp bl,-1 
    jz minore
    
    uguale:  
    lea dx,stringa1
    mov ah,9
    int 21h 
    jmp D
    maggiore: 
    lea dx,stringa2
    mov ah,9
    int 21h
    jmp N
    minore:
    lea dx,stringa3
    mov ah,9
    int 21h 
    
    n:
    d:
.exit
end
   




