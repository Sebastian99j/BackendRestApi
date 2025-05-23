FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

ENV ACCEPT_EULA=Y

RUN apt-get update && apt-get install -y curl  # Instalacja curl

RUN mkdir /https
COPY cert.pfx /https/cert.pfx

EXPOSE 8080
#EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BackendRestApi.csproj", "."]
RUN dotnet restore "./BackendRestApi.csproj"
COPY . . 
WORKDIR "/src/."
RUN dotnet build "./BackendRestApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BackendRestApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV CERT_PATH="/https/cert.pfx"
ENV CERT_PASSWORD="YourStrongPassword"

ENTRYPOINT ["dotnet", "BackendRestApi.dll"]
