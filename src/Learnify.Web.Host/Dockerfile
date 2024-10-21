FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/Learnify.Web.Host/Learnify.Web.Host.csproj", "src/Learnify.Web.Host/"]
COPY ["src/Learnify.Web.Core/Learnify.Web.Core.csproj", "src/Learnify.Web.Core/"]
COPY ["src/Learnify.Application/Learnify.Application.csproj", "src/Learnify.Application/"]
COPY ["src/Learnify.Core/Learnify.Core.csproj", "src/Learnify.Core/"]
COPY ["src/Learnify.EntityFrameworkCore/Learnify.EntityFrameworkCore.csproj", "src/Learnify.EntityFrameworkCore/"]
WORKDIR "/src/src/Learnify.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Learnify.Web.Host", "src/Learnify.Web.Host"]
COPY ["src/Learnify.Web.Core", "src/Learnify.Web.Core"]
COPY ["src/Learnify.Application", "src/Learnify.Application"]
COPY ["src/Learnify.Core", "src/Learnify.Core"]
COPY ["src/Learnify.EntityFrameworkCore", "src/Learnify.EntityFrameworkCore"]
WORKDIR "/src/src/Learnify.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Learnify.Web.Host.dll"]
