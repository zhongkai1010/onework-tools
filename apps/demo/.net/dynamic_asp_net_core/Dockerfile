#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["dynamic_asp_net_core/dynamic_asp_net_core.csproj", "dynamic_asp_net_core/"]
RUN dotnet restore "dynamic_asp_net_core/dynamic_asp_net_core.csproj"
COPY . .
WORKDIR "/src/dynamic_asp_net_core"
RUN dotnet build "dynamic_asp_net_core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dynamic_asp_net_core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dynamic_asp_net_core.dll"]