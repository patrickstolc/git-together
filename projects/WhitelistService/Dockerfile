FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["projects/WhitelistService/WhitelistService.csproj", "projects/WhitelistService/"]
COPY ["shared/Messages/Messages.csproj", "shared/Messages/"]
COPY ["packages/MessageClient/MessageClient.csproj", "packages/MessageClient/"]
COPY ["packages/Topics/Topics.csproj", "packages/Topics/"]
RUN dotnet restore "projects/WhitelistService/WhitelistService.csproj"
COPY . .
WORKDIR "/src/projects/WhitelistService"
RUN dotnet build "WhitelistService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WhitelistService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WhitelistService.dll"]
