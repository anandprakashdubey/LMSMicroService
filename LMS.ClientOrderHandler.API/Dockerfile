#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LMS.ClientOrderHandler.API/LMS.ClientOrderHandler.API.csproj", "LMS.ClientOrderHandler.API/"]
RUN dotnet restore "LMS.ClientOrderHandler.API/LMS.ClientOrderHandler.API.csproj"
COPY . .
WORKDIR "/src/LMS.ClientOrderHandler.API"
RUN dotnet build "LMS.ClientOrderHandler.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LMS.ClientOrderHandler.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LMS.ClientOrderHandler.API.dll"]