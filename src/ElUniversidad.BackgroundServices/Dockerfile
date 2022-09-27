#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ElUniversidad.BackgroundServices/ElUniversidad.BackgroundServices.csproj", "src/ElUniversidad.BackgroundServices/"]
COPY ["src/ElUniversidad.Infrastructure/ElUniversidad.Infrastructure.Data.csproj", "src/ElUniversidad.Infrastructure/"]
COPY ["src/ElUniversidad.Domain/ElUniversidad.Domain.csproj", "src/ElUniversidad.Domain/"]
COPY ["src/RestCountries.Client/RestCountries.Client.csproj", "src/RestCountries.Client/"]
COPY ["src/ElUniversidad.Common.Http/ElUniversidad.Common.Http.csproj", "src/ElUniversidad.Common.Http/"]
COPY ["src/ElUniversidad.Application/ElUniversidad.Application.csproj", "src/ElUniversidad.Application/"]
COPY ["src/Covid19.Client/Covid19.Client.csproj", "src/Covid19.Client/"]
COPY ["src/Econdb.Client/Econdb.Client.csproj", "src/Econdb.Client/"]
RUN dotnet restore "src/ElUniversidad.BackgroundServices/ElUniversidad.BackgroundServices.csproj"
COPY . .
WORKDIR "/src/src/ElUniversidad.BackgroundServices"
RUN dotnet build "ElUniversidad.BackgroundServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ElUniversidad.BackgroundServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElUniversidad.BackgroundServices.dll"]