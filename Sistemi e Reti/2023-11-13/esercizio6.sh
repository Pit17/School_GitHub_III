#!/bin/bash

#Pietro_Malzone_13/11/2023

echo "Inserire il numero"
read number

if (($number < 0));
    then echo "Il numero è negativo"
else
    if (($number > 0));
        then echo "il numero è positivo"
    else
        echo "Il numero è nullo "
    fi
fi