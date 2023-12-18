#!/bin/bash

#Pietro Malzone 3H
nome=ordinamento.txt
ls -l | sort -k5 -r -n | tail -4 | head -1 