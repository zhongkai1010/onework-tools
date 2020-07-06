#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["asp_net_core_autofac/asp_net_core_autofac.csproj", "asp_net_core_autofac/"]
RUN dotnet restore "asp_net_core_autofac/asp_net_core_autofac.csproj"
COPY . .
WORKDIR "/src/asp_net_core_autofac"
RUN dotnet build "asp_net_core_autofac.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "asp_net_core_autofac.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "asp_net_core_autofac.dll"]