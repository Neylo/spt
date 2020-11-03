FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SPTest.UserProcessingService.Api/SPTest.UserProcessingService.Api.csproj", "SPTest.UserProcessingService.Api/"]
COPY ["SP.EventBus/SP.EventBus.csproj", "SP.EventBus/"]
COPY ["SP.Core/SP.Core.csproj", "SP.Core/"]
RUN dotnet restore "SPTest.UserProcessingService.Api/SPTest.UserProcessingService.Api.csproj"
COPY . .
WORKDIR "/src/SPTest.UserProcessingService.Api"
RUN dotnet build "SPTest.UserProcessingService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SPTest.UserProcessingService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SPTest.UserProcessingService.Api.dll"]