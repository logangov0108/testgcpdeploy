#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY . .
COPY WebApplication1/*.csproj ./WebApplication1/
RUN dotnet restore

# copy everything else and build app
COPY WebApplication1/. ./WebApplication1/
WORKDIR /source/WebApplication1
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "WebApplication1.dll"]