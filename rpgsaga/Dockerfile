FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build-env

WORKDIR /app

COPY src/RpgSaga/*.csproj ./RpgSaga/

RUN dotnet restore "RpgSaga/RpgSaga.csproj"

COPY src/ .

WORKDIR /app/RpgSaga

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/runtime:6.0-alpine

WORKDIR /app/src/RpgSaga

COPY --from=build-env /app/RpgSaga/out .

ENTRYPOINT ["dotnet", "RpgSaga.dll"]
