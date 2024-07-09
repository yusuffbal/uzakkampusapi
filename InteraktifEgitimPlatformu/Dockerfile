FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["AYSAPI/AYSAPI.csproj", "AYSAPI/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["SimurgCore/SimurgCore.csproj", "SimurgCore/"]

RUN dotnet restore "AYSAPI/AYSAPI.csproj"
COPY . .
WORKDIR "/src/AYSAPI"
RUN dotnet build "AYSAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AYSAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AYSAPI.dll"]
