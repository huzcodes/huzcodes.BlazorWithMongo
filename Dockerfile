#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 3001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["huzcodes.BlazorWithMongo/huzcodes.BlazorWithMongo.csproj", "huzcodes.BlazorWithMongo/"]
RUN dotnet restore "./huzcodes.BlazorWithMongo/./huzcodes.BlazorWithMongo.csproj"
COPY . .
WORKDIR "/src/huzcodes.BlazorWithMongo"
RUN dotnet build "./huzcodes.BlazorWithMongo.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./huzcodes.BlazorWithMongo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "huzcodes.BlazorWithMongo.dll"]