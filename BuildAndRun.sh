outputFolder="/tmp"
runtime=osx-x64
initialFolder=$(pwd)
gatewayOutputFolder="$outputFolder/Gateway"
gmOutputFolder="$outputFolder/GuestManagement"

echo "$gatewayOutputFolder"
echo "$gmOutputFolder"

cd GuestManagement/
dotnet publish  -o $gmOutputFolder --runtime $runtime --self-contained true  
cd $gmOutputFolder
chmod 777 GuestManagement.API 
./GuestManagement.API &

cd $initialFolder
cd Gateway/
dotnet publish  -o $gatewayOutputFolder --runtime $runtime --self-contained true  
cd $gatewayOutputFolder
chmod 777 Gateway.API
./Gateway.API & 
