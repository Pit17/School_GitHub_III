#!/bin/bash

#Pietro_Malzone_13/11/2023

echo "Inserire il primo valore:"
read value_1
echo "Inserire il secondo valore:"
read value_2

if ((value_1 > value_2));
    then echo "Il numero maggiore è $value_1"
else
    if ((value_2 > value_1));
        then echo "Il numero maggiore è $value_2"
    else 
        echo "I numeri sono uguali"
    fi
fi
