#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TelecomService.Api/TelecomService.Api.csproj", "TelecomService.Api/"]
COPY ["TelecomService.Application/TelecomService.Application.csproj", "TelecomService.Application/"]
COPY ["TelecomService.Domain/TelecomService.Domain.csproj", "TelecomService.Domain/"]
RUN dotnet restore "TelecomService.Api/TelecomService.Api.csproj"
COPY . .
WORKDIR "/src/TelecomService.Api"
RUN dotnet build "TelecomService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TelecomService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TelecomService.Api.dll"]
