FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["challenge-api-dotnet/challenge-api-dotnet.csproj", "challenge-api-dotnet/"]
RUN dotnet restore "challenge-api-dotnet/challenge-api-dotnet.csproj"
COPY . .
WORKDIR "/src/challenge-api-dotnet"
RUN dotnet build "challenge-api-dotnet.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "challenge-api-dotnet.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "challenge-api-dotnet.dll"]
