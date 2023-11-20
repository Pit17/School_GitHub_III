#!/bin/bash

#Pietro_Malzone_20/11/2023

echo "1 per il nome"
echo "2 per il nome con cui tutti ti chiamano"
echo "3 per il nome dell'animale"


read scelta
WORD=""

case $scelta in 
    "1")
    read -p "Inserisci il tuo nome: " WORD
    echo "Il tuo nome è $WORD"
    ;;
    "2")
    read -p "inserisci come ti chiamano: " WORD
    echo "Tutti ti chiamano $WORD"
    ;;
    "3")
    read -p "Inserisci come si chiama il tuo animale: " WORD
    echo "Il tuo animale si chiama $WORD"
    ;;
    *) #caso default
    echo "Scelta non disponibile"
    ;;
esac