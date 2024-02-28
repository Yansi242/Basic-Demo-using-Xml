#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LoginApiDemo/LoginApiDemo.csproj", "LoginApiDemo/"]
COPY ["LoginApiDemo.Data/LoginApiDemo.Data.csproj", "LoginApiDemo.Data/"]
COPY ["LoginApiDemo.common/LoginApiDemo.Common.csproj", "LoginApiDemo.common/"]
COPY ["LoginApiDemo.Model/LoginApiDemo.Model.csproj", "LoginApiDemo.Model/"]
COPY ["LoginApiDemo.Service/LoginApiDemo.Service.csproj", "LoginApiDemo.Service/"]
RUN dotnet restore "./LoginApiDemo/./LoginApiDemo.csproj"
COPY . .
WORKDIR "/src/LoginApiDemo"
RUN dotnet build "./LoginApiDemo.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LoginApiDemo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoginApiDemo.dll"]