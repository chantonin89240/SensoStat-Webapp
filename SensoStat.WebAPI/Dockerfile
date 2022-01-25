#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SensoStat.WebAPI/SensoStat.WebAPI.csproj", "SensoStat.WebAPI/"]
RUN dotnet restore "SensoStat.WebAPI/SensoStat.WebAPI.csproj"
COPY . .
WORKDIR "/src/SensoStat.WebAPI"
RUN dotnet build "SensoStat.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SensoStat.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SensoStat.WebAPI.dll"]