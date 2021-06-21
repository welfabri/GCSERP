#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IU/GCS.ERP.Identidade.MVC/GCS.ERP.Identidade.MVC.csproj", "IU/GCS.ERP.Identidade.MVC/"]
RUN dotnet restore "IU/GCS.ERP.Identidade.MVC/GCS.ERP.Identidade.MVC.csproj"
COPY . .
WORKDIR "/src/IU/GCS.ERP.Identidade.MVC"
RUN dotnet build "GCS.ERP.Identidade.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GCS.ERP.Identidade.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GCS.ERP.Identidade.MVC.dll"]