FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/proAdministration.API/proAdministration.API.csproj", "src/proAdministration.API/"]
COPY ["src/proAdministration.Data/proAdministration.Data.csproj", "src/proAdministration.Data/"]
COPY ["src/proAdministration.Shared/proAdministration.Shared.csproj", "src/proAdministration.Shared/"]
RUN dotnet restore "src/proAdministration.API/proAdministration.API.csproj"
COPY . .
WORKDIR "/src/src/proAdministration.API"
RUN dotnet build "proAdministration.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "proAdministration.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "proAdministration.API.dll"]
