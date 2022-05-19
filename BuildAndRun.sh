outputFolder="/tmp/GM/"
runtime=osx-x64 

cd GuestManagement.API/
dotnet clean
dotnet publish  -o $outputFolder --runtime $runtime --self-contained true  
cd $outputFolder
chmod 777 GuestManagement.API
./GuestManagement.API