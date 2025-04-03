FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80
COPY Shared/Category.Shared/CategoryService.Shared.csproj Shared/Category.Shared/
COPY src/Services/FakePaymentService/FakePaymentService.Api/FakePaymentService.Api.csproj src/Services/FakePaymentService/FakePaymentService.Api/

RUN dotnet restore src/Services/FakePaymentService/FakePaymentService.Api/FakePaymentService.Api.csproj

COPY . .

RUN dotnet publish src/Services/FakePaymentService/FakePaymentService.Api/FakePaymentService.Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "FakePaymentService.Api.dll"]
