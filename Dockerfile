FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app

ENV ASPNETCORE_URLS http://+:8088

EXPOSE 8088

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY TranscriptSandbox.API/*.csproj ./TranscriptSandbox.API/
RUN dotnet restore

# Copy everything else and build
COPY TranscriptSandbox.API/. ./TranscriptSandbox.API/
RUN dotnet publish -c Release -o out
WORKDIR /app/out
ENTRYPOINT ["dotnet", "TranscriptSandbox.API.dll"]

# Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:5.0
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "aspnetapp.dll"]