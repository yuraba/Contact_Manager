FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["McLaren/McLaren.csproj", "McLaren/"]
RUN dotnet restore "McLaren/McLaren.csproj"
COPY . .
WORKDIR "/src/McLaren"
RUN dotnet build "McLaren.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "McLaren.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "McLaren.dll"]
