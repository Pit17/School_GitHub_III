#!/bin/bash

#Pietro Malzone 3H

echo "Fino a quale numero desidera stampare?"

read n
i=0

while (( $i<=$n )) 
do
    echo "$i;"
    let "i+=1"
done
