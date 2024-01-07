#!/bin/bash

echo "Quanti file desidera creare?  -->"

read n



for (( i = 0; i < $n; i++ )) do 

    touch $i.txt

    echo "Quante righe desidera scrivere? -->"

    read n_l

    for (( j = 0; j < $n_l; )) do

        echo "Inserire la riga --> "

        read string

        echo -e $string >> $i.txt

    done

done

ls | grep -v '.sh' | sort | tail -1

echo "-----------------------------------"

ls -l | grep -v '.sh' | sort -k5 