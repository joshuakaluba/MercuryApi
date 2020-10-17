FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./src/MercuryApi.Web/MercuryApi.Web.csproj ./MercuryApi.Web/MercuryApi.Web.csproj
COPY ./src/MercuryApi.Data/MercuryApi.Data.csproj ./MercuryApi.Data/MercuryApi.Data.csproj
RUN dotnet restore ./MercuryApi.Web/MercuryApi.Web.csproj

# Copy everything else and build
COPY ./src ./
RUN dotnet publish ./MercuryApi.Web/MercuryApi.Web.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MercuryApi.Web.dll"]