FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TimeTrackerAutomationSWD/TimeTrackerAutomationSWD.csproj", "TimeTrackerAutomationSWD/"]
RUN dotnet restore "TimeTrackerAutomationSWD/TimeTrackerAutomationSWD.csproj"
COPY . .
WORKDIR "/src/TimeTrackerAutomationSWD"
RUN dotnet build "TimeTrackerAutomationSWD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TimeTrackerAutomationSWD.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeTrackerAutomationSWD.dll"]
