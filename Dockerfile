# Base image: runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Build image: SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy file csproj đúng đường dẫn
COPY BloodDonation-SWD/BloodDonation-SWD.csproj BloodDonation-SWD/

# Restore dependencies
RUN dotnet restore BloodDonation-SWD/BloodDonation-SWD.csproj

# Copy toàn bộ source code
COPY . .

# Publish app (build) trong thư mục csproj
WORKDIR /src/BloodDonation-SWD
RUN dotnet publish -c Release -o /app/publish

# Build final image
FROM base AS final
WORKDIR /app

# Copy app đã build từ bước trước
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "BloodDonation-SWD.dll"]
