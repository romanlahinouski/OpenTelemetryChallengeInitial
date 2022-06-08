#!/bin/bash

outputFolder="/tmp"
runtime=osx-x64
initialFolder=$(pwd)
gatewayOutputFolder="$outputFolder/Gateway"
gmOutputFolder="$outputFolder/GuestManagement"

echo "$gatewayOutputFolder"
echo "$gmOutputFolder"


servicePidsFile="Services.pid"


if [ -e "Services.pid" ]
then
     rm -f "Services.pid"
else
    echo "No pid file found"
fi


cd GuestManagement/
dotnet publish  -o $gmOutputFolder --runtime $runtime --self-contained true  
cd $gmOutputFolder
chmod 777 GuestManagement.API 
./GuestManagement.API &

printf "$!\n" >> "$initialFolder/$servicePidsFile"

cd $initialFolder
cd Gateway/Gateway.API
dotnet publish  -o $gatewayOutputFolder --runtime $runtime --self-contained true  
cd $gatewayOutputFolder
chmod 777 Gateway.API
./Gateway.API & 
printf $! >> "$initialFolder/$servicePidsFile"
