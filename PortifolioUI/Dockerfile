FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

ENV ASPNETCORE_ENVIRONMENT=Development 

ENV TZ="America/Sao_Paulo" 

WORKDIR /App

ENTRYPOINT ["dotnet", "PortifolioUI.dll"]

EXPOSE 8080
EXPOSE 8081
