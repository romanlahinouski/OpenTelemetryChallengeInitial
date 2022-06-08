initialFolder=$(pwd)
cd GuestManagement/
dotnet restore

cd $initialFolder
cd Gateway/Gateway.API
dotnet restore