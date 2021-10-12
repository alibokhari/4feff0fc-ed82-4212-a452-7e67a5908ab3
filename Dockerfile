FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY . .
RUN dotnet restore

RUN dotnet restore

RUN dotnet test

ENTRYPOINT ["dotnet", "test"]