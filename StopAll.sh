#!/bin/bash

filename='Services.pid'
n=1
while read -r line || [[ -n $line ]];
 do

echo "$line"
kill $line

done < $filename