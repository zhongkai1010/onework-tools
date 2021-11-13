FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["asp_net_docker/asp_net_docker.csproj", "asp_net_docker/"]
RUN dotnet restore "asp_net_docker/asp_net_docker.csproj"
COPY . .
WORKDIR "/src/asp_net_docker"
RUN dotnet build "asp_net_docker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "asp_net_docker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "asp_net_docker.dll"]