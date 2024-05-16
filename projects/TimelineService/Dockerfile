FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["projects/TimelineService/TimelineService.csproj", "projects/TimelineService/"]
RUN dotnet restore "projects/TimelineService/TimelineService.csproj"
COPY . .
WORKDIR "/src/projects/TimelineService"
RUN dotnet build "TimelineService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TimelineService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimelineService.dll"]
