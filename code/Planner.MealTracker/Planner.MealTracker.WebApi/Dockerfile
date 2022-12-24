#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Planner.MealTracker.WebApi/Planner.MealTracker.WebApi.csproj", "Planner.MealTracker.WebApi/"]
RUN dotnet restore "Planner.MealTracker.WebApi/Planner.MealTracker.WebApi.csproj"
COPY . .
WORKDIR "/src/Planner.MealTracker.WebApi"
RUN dotnet build "Planner.MealTracker.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Planner.MealTracker.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Planner.MealTracker.WebApi.dll"]