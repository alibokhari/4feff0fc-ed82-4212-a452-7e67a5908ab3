#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["NumberSequence/NumberSequence.csproj", "NumberSequence/"]
RUN dotnet restore "NumberSequence/NumberSequence.csproj"
COPY . .
WORKDIR "/src/NumberSequence"
RUN dotnet build "NumberSequence.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NumberSequence.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NumberSequence.dll"]