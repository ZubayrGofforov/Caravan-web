FROM mcr.microsoft.com/dotnet/sdk:6.0
COPY . .
RUN dotnet restore
RUN dotnet publish -c release -o out
CMD [ "dotnet", "Caravan.dll" ]