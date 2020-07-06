#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["OneWork.Web.App/OneWork.Web.App.csproj", "OneWork.Web.App/"]
RUN dotnet restore "OneWork.Web.App/OneWork.Web.App.csproj"
COPY . .
WORKDIR "/src/OneWork.Web.App"
RUN dotnet build "OneWork.Web.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OneWork.Web.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OneWork.Web.App.dll"]