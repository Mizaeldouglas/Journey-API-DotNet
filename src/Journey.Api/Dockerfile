FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Journey.Api/Journey.Api.csproj", "Journey.Api/"]
COPY ["Journey.Application/Journey.Application.csproj", "Journey.Application/"]
COPY ["Journey.Communication/Journey.Communication.csproj", "Journey.Communication/"]
COPY ["Journey.Exception/Journey.Exception.csproj", "Journey.Exception/"]
COPY ["Journey.Infrastructure/Journey.Infrastructure.csproj", "Journey.Infrastructure/"]
RUN dotnet restore "Journey.Api/Journey.Api.csproj"
COPY . .
WORKDIR "/src/Journey.Api"
RUN dotnet build "Journey.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Journey.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Journey.Api.dll"]