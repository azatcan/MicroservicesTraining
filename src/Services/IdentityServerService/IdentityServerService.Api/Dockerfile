FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80
COPY ./Shared/Category.Shared/CategoryService.Shared.csproj ./Shared/Category.Shared/
COPY ./src/Services/IdentityServerService/IdentityServerService.Api/IdentityServerService.Api.csproj ./src/Services/IdentityServerService/IdentityServerService.Api/
RUN dotnet restore ./src/Services/IdentityServerService/IdentityServerService.Api/IdentityServerService.Api.csproj
COPY . .
RUN dotnet publish ./src/Services/IdentityServerService/IdentityServerService.Api/IdentityServerService.Api.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "IdentityServerService.Api.dll" ]




