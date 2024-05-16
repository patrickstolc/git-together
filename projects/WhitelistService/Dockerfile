FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["git-together/projects/WhitelistService/WhitelistService.csproj", "git-together/projects/WhitelistService/"]
COPY ["git-together/shared/Messages/Messages.csproj", "git-together/shared/Messages/"]
COPY ["git-together/packages/MessageClient/MessageClient.csproj", "git-together/packages/MessageClient/"]
COPY ["git-together/packages/Topics/Topics.csproj", "git-together/packages/Topics/"]
RUN dotnet restore "git-together/projects/WhitelistService/WhitelistService.csproj"
COPY . .
WORKDIR "/src/git-together/projects/WhitelistService"
RUN dotnet build "WhitelistService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WhitelistService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WhitelistService.dll"]
