FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

# docker images are just layers upon one another, so the command below defines the base image for which our instructions derive from.
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
ARG BUILDCONFIG=RELEASE
ARG VERSION=0.0.1

# Copy csproj and restore as distinct layers. PResumably this copies the csproj into /app ?
COPY . .

RUN dotnet restore "API.FPL.NET/API.FPL.NET.csproj"

FROM build AS publish
RUN dotnet publish "API.FPL.NET/API.FPL.NET.csproj" --no-restore -c Release -o /app

# buiod runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app .

# Entrypoint takes array and transforms it into a command line invocation with arguments (dotnet API.NET.dll)
ENTRYPOINT ["dotnet", "API.FPL.NET.dll"]
