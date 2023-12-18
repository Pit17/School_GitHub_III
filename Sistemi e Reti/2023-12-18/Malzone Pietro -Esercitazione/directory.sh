#!/bin/bash

#Pietro Malzone 3H
LIMITE=5

echo "Che nome vuole dare alla cartella?"

read name

mkdir $name

cd $name

numero=$RANDOM
numero=$((numero%LIMITE))
let "numero+=4"
for ((i=1;i<=numero+1;i++)) do

    nomeDir=verifica$i
    mkdir $nomeDir
done
