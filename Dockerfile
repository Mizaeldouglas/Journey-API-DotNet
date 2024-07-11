FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Journey.Api/Journey.Api.csproj", "Journey.Api/"]
COPY ["src/Journey.Application/Journey.Application.csproj", "Journey.Application/"]
COPY ["src/Journey.Communication/Journey.Communication.csproj", "Journey.Communication/"]
COPY ["src/Journey.Exception/Journey.Exception.csproj", "Journey.Exception/"]
COPY ["src/Journey.Infrastructure/Journey.Infrastructure.csproj", "Journey.Infrastructure/"]
RUN dotnet restore "Journey.Api/Journey.Api.csproj"
COPY . .
WORKDIR "/src/Journey.Api"
RUN dotnet build "src/Journey.Api/Journey.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "src/Journey.Api/Journey.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Journey.Api.dll"]