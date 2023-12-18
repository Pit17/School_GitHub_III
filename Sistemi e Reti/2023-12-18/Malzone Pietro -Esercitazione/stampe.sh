#!/bin/bash

#Pietro Malzone 3H

echo "Che nome vuole dare al primo file?"

read n1

echo "Che nome vuole dare al secondo file?"

read n2

touch $n1.txt
touch $n2.txt

echo "Dashing through the snow In a one-horse open sleigh" >> $n1.txt
echo "O'er the fields we go Laughing all the way" >> $n1.txt
echo "Bells on bobtails ring Making spirits bright" >> $n1.txt
echo "What fun it is to ride and sing A sleighing song tonight" >> $n1.txt

echo "Jingle bells, jingle bells Jingle all the way" >> $n2.txt
echo "Oh, what fun it is to ride In a one-horse open sleigh, hey" >> $n2.txt
echo "Jingle bells, jingle bells Jingle all the way" >> $n2.txt
echo "Oh, what fun it is to ride In a one-horse open sleigh" >> $n2.txt

echo "---------------------------------------------------------------------------"

nome=canzone.txt
cat $n1.txt $n2.txt >> $nome

grep 'ride' $nome
echo "---------------------------------------------------------------------------"
grep -v 'horse' $nome
echo "---------------------------------------------------------------------------"

echo "Che nome vuole dare al file finale?"

read name

name=$name.txt
touch $name

head -5 $nome | tail -1 | echo -e >> $name



