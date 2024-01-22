name 'Equazione1' ; Pietro Malzone 3h 22/01/2024    

.MODEL small

.stack

.data

    Y dw ?
    X dw 10
    Z dw 1
    W dw 1
    T dw 1          
    Aus dw ?  
    
.code 
    .startup
        MOV AX,X
        ADD AX,X
        ADD AX,X
        ADD AX,X
        ADD AX,X
        ADD AX,X
        SUB AX,Z
        SUB AX,Z
        SUB AX,Z
        SUB AX,Z
        SUB AX,Z
        SUB AX,Z
        SUB AX,Z
        SUB AX,Z
        SUB AX,Z
        ADD AX,W
        ADD AX,W
        ADD AX,W
        ADD AX,T
        ADD AX,T
        MOV BX,Z
        ADD BX,T          
        MOV Aus,BX
        SUB AX,Aus
        SUB AX,Aus
        SUB AX,Aus
        SUB AX,Aus 
        MOV Y,AX
      .exit
end