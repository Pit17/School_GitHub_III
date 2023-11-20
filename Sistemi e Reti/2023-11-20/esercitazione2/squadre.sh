#!/bin/bash

#Pietro_Malzone_13/11/2023
NUM_MAX=6
numero=$RANDOM
numero=$(($numero%$NUM_MAX))
let "numero+=1"

case $numero in 
    "1")
        echo "La tua squadra è la squadra ROSSA poichè è uscito il numero : $numero"
    ;;
    "2")
        echo "La tua squadra è la squadra VERDE poichè è uscito il numero : $numero"
    ;;
    "3")
        echo "La tua squadra è la squadra GIALLA poichè è uscito il numero : $numero"
    ;;
    "4")
        echo "La tua squadra è la squadra BLU poichè è uscito il numero : $numero"
    ;;
    "5")
        echo "La tua squadra è la squadra ROSA poichè è uscito il numero : $numero"
    ;;
    "6")
        echo "La tua squadra è la squadra NERA poichè è uscito il numero : $numero"
    ;;
esac


