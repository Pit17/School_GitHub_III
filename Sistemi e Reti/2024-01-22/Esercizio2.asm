name 'esercizio2' ; Pietro Malzone 3H

.MODEl small
  
.STACK
  
.DATA
  
  X dw 10
  Y dw 5
  Z dw 2      
  W dw ?
  
.CODE
    .STARTUP 
        MOV AX,X
        SUB AX,Y
        SUB AX,Y
        ADD AX,Z
        ADD AX,Z
        ADD AX,Z  
        MOV W,AX
    .EXIT
END    