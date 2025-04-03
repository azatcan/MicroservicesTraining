FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80
COPY ./Shared/Category.Shared/CategoryService.Shared.csproj ./Shared/Category.Shared/
COPY ./Clients/MicroService.WebApp/MicroService.WebApp.csproj ./Clients/MicroService.WebApp/
RUN dotnet restore ./Clients/MicroService.WebApp/MicroService.WebApp.csproj
COPY . .
RUN dotnet publish ./Clients/MicroService.WebApp/MicroService.WebApp.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/sdk:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroService.WebApp.dll" ]