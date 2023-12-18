#!/bin/bash

#Pietro Malzone 3H

echo "Di quale numero desidera visualizzare la tabellina?"
read n
numero=0

for ((i=0; i<=10; i++)) do

    let "numero=n*i"
    echo "$n X $i = $numero"

done