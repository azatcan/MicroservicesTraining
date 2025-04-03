FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80
COPY ./Shared/Category.Shared/CategoryService.Shared.csproj ./Shared/Category.Shared/

COPY ./src/Services/BasketService/BasketService.Application/BasketService.Application.csproj ./src/Services/BasketService/BasketService.Application/
COPY ./src/Services/BasketService/BasketService.Domain/BasketService.Domain.csproj ./src/Services/BasketService/BasketService.Domain/
COPY ./src/Services/BasketService/BasketService.Infrastructure/BasketService.Infrastructure.csproj ./src/Services/BasketService/BasketService.Infrastructure/

COPY ./src/Services/BasketService/BasketService.Api/BasketService.Api.csproj ./src/Services/BasketService/BasketService.Api/
RUN dotnet restore ./src/Services/BasketService/BasketService.Api/BasketService.Api.csproj
COPY . .
RUN dotnet publish ./src/Services/BasketService/BasketService.Api/BasketService.Api.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/sdk:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","BasketService.Api.dll" ]