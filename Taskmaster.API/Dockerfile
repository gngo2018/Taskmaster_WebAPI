FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY Taskmaster.API/Taskmaster.API.csproj Taskmaster.API/
COPY Taskmaster.API.DataContract/Taskmaster.API.DataContract.csproj Taskmaster.API.DataContract/
COPY Taskmaster.Data/Taskmaster.Data.csproj Taskmaster.Data/
COPY Taskmaster.Data.DataContract/Taskmaster.Data.DataContract.csproj Taskmaster.Data.DataContract/
COPY Taskmaster.Business.DataContract/Taskmaster.Business.DataContract.csproj Taskmaster.Business.DataContract/
COPY Taskmaster.Business/Taskmaster.Business.csproj Taskmaster.Business/
RUN dotnet restore "Taskmaster.API/Taskmaster.API.csproj"
COPY . .
WORKDIR "/src/Taskmaster.API"
RUN dotnet build "Taskmaster.API.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Taskmaster.API.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Taskmaster.API.dll"]
