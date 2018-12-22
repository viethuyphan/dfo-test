FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY DFO.Assignment.API/DFO.Assignment.API.csproj DFO.Assignment.API/

RUN dotnet restore DFO.Assignment.API/DFO.Assignment.API.csproj
COPY . .
WORKDIR /src/DFO.Assignment.API
RUN dotnet build DFO.Assignment.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DFO.Assignment.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DFO.Assignment.API.dll"]
