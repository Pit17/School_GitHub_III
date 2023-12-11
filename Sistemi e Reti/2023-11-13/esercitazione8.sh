#!/bin/bash

#Pietro_Malzone_13/11/2023

numero=${RANDOM:0:1}

if (($numero == 1));
    then echo "La tua squadra è la squadra ROSSA poichè è uscito il numero : $numero"
else 
    if (($numero == 2));
        then echo "La tua squadra è la squadra VERDE poichè è uscito il numero : $numero"
    else 
        if (($numero == 3));
            then echo "La tua squadra è la squadra GIALLA poichè è uscito il numero : $numero"
        else
            if (($numero == 4));
                then echo "La tua squadra è la squadra BLU poichè è uscito il numero : $numero"
            else
                if (($numero == 5));
                    then echo "La tua squadra è la squadra ROSA poichè è uscito il numero : $numero"
                else 
                    if (($numero == 6));
                        then echo "La tua squadra è la squadra NERA poichè è uscito il numero : $numero"
                    else 
                        echo "Non puoi giocare poichè è uscito il numero : $numero"
                    fi
                fi
            fi
        fi
    fi
fi

