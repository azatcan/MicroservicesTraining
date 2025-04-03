FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80
COPY ./Shared/Category.Shared/CategoryService.Shared.csproj ./Shared/Category.Shared/
COPY ./src/Services/PhotoStockService/PhotoStockService.Api/PhotoStockService.Api.csproj ./src/Services/PhotoStockService/PhotoStockService.Api/
RUN dotnet restore ./src/Services/PhotoStockService/PhotoStockService.Api/PhotoStockService.Api.csproj
COPY . .
RUN dotnet publish ./src/Services/PhotoStockService/PhotoStockService.Api/PhotoStockService.Api.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "PhotoStockService.Api.dll"]