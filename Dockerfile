FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY BloodDonation-SWD/BloodDonation-SWD.csproj BloodDonation-SWD/
RUN dotnet restore BloodDonation-SWD/BloodDonation-SWD.csproj

COPY . .
WORKDIR /src/BloodDonation-SWD
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BloodDonation-SWD.dll"]
