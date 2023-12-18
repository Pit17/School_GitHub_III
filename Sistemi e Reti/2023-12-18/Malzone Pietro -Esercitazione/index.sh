#!/bin/bash

#Pietro Malzone 3H
ciclo=1

while (($ciclo))
do
    echo "Quale programma desidera eseguire?"
    echo "1) Stampa la tabellina"
    echo "2) Scrivi numeri"
    echo "3) Creazione di directory e file"
    echo "4) Concatenazione, ricerca, ordinamento"
    echo "5) Ordinamento e stampa su nuovo file"
    echo "6) Uscire dal programma"
    read answer

    case $answer in 
        "1")
            ./tabellina.sh 
        ;;
        "2")
            ./numeri.sh
        ;;
        "3")
            ./directory.sh            
        ;;
        "4")
            ./stampe.sh 
        ;;
        "5")
            ./ordinamento.sh
        ;;
        "6")
            let "ciclo-=1"
        ;;

    esac            
done


