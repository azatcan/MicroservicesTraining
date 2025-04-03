FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80

COPY  ./Gateways/Gateway.Api/Gateway.Api.csproj  ./Gateways/Gateway.Api/
RUN dotnet restore ./Gateways/Gateway.Api/Gateway.Api.csproj
COPY . .
RUN dotnet publish ./Gateways/Gateway.Api/Gateway.Api.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/sdk:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Gateway.Api.dll" ]