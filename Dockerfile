#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PersonAPI/Nuget.config", "PersonAPI/"]
COPY ["PersonAPI/PersonDirectory.Presentation.WebApi.csproj", "PersonAPI/"]
COPY ["PersonDirectory.Infrastructure.Persistence/PersonDirectory.Infrastructure.Persistence.csproj", "PersonDirectory.Infrastructure.Persistence/"]
COPY ["PersonDirectory.Core.Domain/PersonDirectory.Core.Domain.csproj", "PersonDirectory.Core.Domain/"]
COPY ["PersonDirectory.Application/PersonDirectory.Application.csproj", "PersonDirectory.Application/"]
COPY ["PersonDirectory.Infrastructure.FileService/PersonDirectory.Infrastructure.FileService.csproj", "PersonDirectory.Infrastructure.FileService/"]
RUN dotnet restore "PersonAPI/PersonDirectory.Presentation.WebApi.csproj"
COPY . .
WORKDIR "/src/PersonAPI"
RUN dotnet build "PersonDirectory.Presentation.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonDirectory.Presentation.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonDirectory.Presentation.WebApi.dll"]