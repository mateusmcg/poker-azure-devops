FROM microsoft/dotnet:2.1-sdk
WORKDIR /app

COPY ./PokerAzureDevops/*.csproj ./
RUN dotnet restore

COPY ./PokerAzureDevops/ ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/PokerAzureDevops.dll"]