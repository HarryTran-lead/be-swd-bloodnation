# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY BloodDonation-SWD.csproj .
RUN dotnet restore BloodDonation-SWD.csproj
COPY . .
RUN dotnet publish BloodDonation-SWD.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "BloodDonation-SWD.dll"]
