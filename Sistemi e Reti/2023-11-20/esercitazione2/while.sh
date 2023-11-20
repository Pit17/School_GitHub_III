#!/bin/bash

#Pietro_Malzone_20/11/2023


NUM_MAX=10
CICLI=10
contatore=1

echo
echo "$NUM_MAX numeri casuali:"
echo "--------------------"
while(( $contatore <= $CICLI ))
do
    numero=$RANDOM
    numero=$(($numero%$NUM_MAX))
    echo $numero
    let "contatore+=1"
done