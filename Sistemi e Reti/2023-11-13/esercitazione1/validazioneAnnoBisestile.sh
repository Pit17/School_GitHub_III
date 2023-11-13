#!/bin/bash

#Pietro_Malzone_13/11/2023

echo "Inserisca l'anno che desidera verificare"
read year


if (($year % 100 == 0 && $year % 400 == 0));
    then echo "L'anno $year è bisestile"
else 
    if (($year % 4 == 0));
        then echo "L'anno $year è bisestile"
    else
        echo "L'anno $year è bisestile"
    fi
fi