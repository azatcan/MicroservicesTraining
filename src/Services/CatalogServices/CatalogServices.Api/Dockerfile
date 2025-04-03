FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80
COPY Shared/Category.Shared/CategoryService.Shared.csproj Shared/Category.Shared/

COPY src/Services/CatalogServices/CatalogService.Application/CatalogService.Application.csproj src/Services/CatalogServices/CatalogService.Application/
COPY src/Services/CatalogServices/CatalogService.Domain/CatalogService.Domain.csproj src/Services/CatalogServices/CatalogService.Domain/
COPY src/Services/CatalogServices/CatalogService.Infrastructure/CatalogService.Infrastructure.csproj src/Services/CatalogService.Infrastructure/CatalogService.Infrastructure/

COPY src/Services/CatalogServices/CatalogServices.Api/CatalogServices.Api.csproj src/Services/CatalogServices/CatalogServices.Api/
RUN dotnet restore src/Services/CatalogServices/CatalogServices.Api/CatalogServices.Api.csproj
COPY . .
RUN dotnet publish src/Services/CatalogServices/CatalogServices.Api/CatalogServices.Api.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "CatalogServices.Api.dll"]




