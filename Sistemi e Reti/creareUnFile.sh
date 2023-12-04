#!/bin/bash

#Pietro_Malzone_04/12/2023

echo "Inserisci il nome del file da creare"
read nomeFile

nome=$nomeFile.txt
ciclo=1

touch $nome

echo "File $nome creato"

while (( $ciclo ))
do
    echo "Premere 1 per scrivere la prossima frase da inserire nel file"
    echo "Premre 2 per terminare il programma e leggere a video il contenuto del file"
    read risposta
    if (($risposta == 1))
    then 
        echo "Inserisci la frase da scrivere nel file:" #chiedo le stringhe
        read stringa
        echo -e "$stringa" >> $nome
    else
        let "ciclo-=1" #cambio la varibile ciclo per uscire dal while

        cat $nome

        echo "+---------------------------------------------+" #eseguo i 4 grep
        echo "Grep con MnB:"
        grep '[MnB]' $nome
        echo "+---------------------------------------------+"
        echo "Grep con presenza di numeri:"
        grep '[0-9]' $nome
        echo "+---------------------------------------------+"
        echo "Grep senza la presenza della parola prova:"
        grep -v 'prova' $nome
        echo "+---------------------------------------------+"
        echo "Grep con caratteri maiuscoli:"
        grep '[A-Z]' $nome
        echo "+---------------------------------------------+"
    fi
done