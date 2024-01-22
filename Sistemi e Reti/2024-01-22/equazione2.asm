name 'equazione2' ; Pietro Malzone
.model small

.data
    y dw ?
    x dw 1
    aus dw ?
.code
    .startup
    
        mov ax,x
        mov bx,ax
        mul bx
        mul bx  
        add ax,bx
        add ax,bx
        add ax,bx
        mov aus,ax
        sub ax,ax
        sub bx,bx
        mov ax,x 
        mov bx,ax
        mul bx
        add ax,x
        add ax,x 
        add ax,aus
        add ax,x
        add ax,x
        add ax,7
		mov y,ax
     .exit
     
end        
        
        