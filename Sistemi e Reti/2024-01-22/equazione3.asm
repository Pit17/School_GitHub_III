name 'equazione3' ;Pietro Malzone 3H  
.model small
.data
    x dw 1
    y dw 1
    aus dw ?
    res dw ?
.code
    .startup
        mov ax,x
        mul x
        mov aus,ax
        mov ax,y
        mul y
        add aus,ax       
        mov ax,x
        mul y
        mov bx,2
        mul bx
        add ax,aus
        mov res,ax
     .exit
end        