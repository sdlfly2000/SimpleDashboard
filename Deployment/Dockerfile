#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY . .

EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=https://+:443;http://+:80 
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=SimpleDashboardCert.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=sdl@1215

ENTRYPOINT ["dotnet", "Presentation.Web.Api.dll"]
