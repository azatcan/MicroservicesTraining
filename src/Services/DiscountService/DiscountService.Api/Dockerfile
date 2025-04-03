FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80
COPY ./Shared/Category.Shared/CategoryService.Shared.csproj ./Shared/Category.Shared/
COPY ./src/Services/DiscountService/DiscountService.Api/DiscountService.Api.csproj ./src/Services/DiscountService/DiscountService.Api/
RUN dotnet restore ./src/Services/DiscountService/DiscountService.Api/DiscountService.Api.csproj
COPY . .
RUN dotnet publish ./src/Services/DiscountService/DiscountService.Api/DiscountService.Api.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/sdk:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","DiscountService.Api.dll" ]