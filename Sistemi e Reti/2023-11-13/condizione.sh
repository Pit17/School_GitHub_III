#!/bin/bash

#Pietro_Malzone_13/11/2023

valore=15
if [ $valore -eq 10 ];
    then echo "Il valore è uguale a 10"
else
    echo "......"
fi

if (($valore == 10));
    then echo "Il valore è uguale a 10"
else
    echo "......"
fi


 #-eq --> ==
 #-ne --> !=
 #-gt --> >
 #-ge --> >=
 #-lt --> <
 #-le --> <=