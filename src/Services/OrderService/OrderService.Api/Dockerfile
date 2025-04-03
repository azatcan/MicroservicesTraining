FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80
COPY ./Shared/Category.Shared/CategoryService.Shared.csproj ./Shared/Category.Shared/

COPY ./src/Services/OrderService/OrderService.Application/OrderService.Application.csproj ./src/Services/OrderService/OrderService.Application/

COPY ./src/Services/OrderService/OrderService.Domain/OrderService.Domain.csproj ./src/Services/OrderService/OrderService.Domain/

COPY ./src/Services/OrderService/OrderService.Domain.Core/OrderService.Domain.Core.csproj ./src/Services/OrderService/OrderService.Domain.Core/

COPY ./src/Services/OrderService/OrderService.Infrastructure/OrderService.Infrastructure.csproj ./src/Services/OrderService/OrderService.Infrastructure/


COPY ./src/Services/OrderService/OrderService.Api/OrderService.Api.csproj ./src/Services/OrderService/OrderService.Api/
RUN dotnet restore ./src/Services/OrderService/OrderService.Api/OrderService.Api.csproj
COPY . .
RUN dotnet publish ./src/Services/OrderService/OrderService.Api/OrderService.Api.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/sdk:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","OrderService.Api.dll" ]