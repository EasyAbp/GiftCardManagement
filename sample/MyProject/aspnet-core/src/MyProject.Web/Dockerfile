#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["sample/MyProject/aspnet-core/src/MyProject.Web/MyProject.Web.csproj", "sample/MyProject/aspnet-core/src/MyProject.Web/"]
COPY ["sample/MyProject/aspnet-core/src/MyProject.HttpApi/MyProject.HttpApi.csproj", "sample/MyProject/aspnet-core/src/MyProject.HttpApi/"]
COPY ["src/EasyAbp.GiftCardManagement.HttpApi/EasyAbp.GiftCardManagement.HttpApi.csproj", "src/EasyAbp.GiftCardManagement.HttpApi/"]
COPY ["src/EasyAbp.GiftCardManagement.Application.Contracts/EasyAbp.GiftCardManagement.Application.Contracts.csproj", "src/EasyAbp.GiftCardManagement.Application.Contracts/"]
COPY ["src/EasyAbp.GiftCardManagement.Domain.Shared/EasyAbp.GiftCardManagement.Domain.Shared.csproj", "src/EasyAbp.GiftCardManagement.Domain.Shared/"]
COPY ["sample/MyProject/aspnet-core/src/MyProject.Application.Contracts/MyProject.Application.Contracts.csproj", "sample/MyProject/aspnet-core/src/MyProject.Application.Contracts/"]
COPY ["sample/MyProject/aspnet-core/src/MyProject.Domain.Shared/MyProject.Domain.Shared.csproj", "sample/MyProject/aspnet-core/src/MyProject.Domain.Shared/"]
COPY ["sample/MyProject/aspnet-core/src/MyProject.Application/MyProject.Application.csproj", "sample/MyProject/aspnet-core/src/MyProject.Application/"]
COPY ["sample/MyProject/aspnet-core/src/MyProject.Domain/MyProject.Domain.csproj", "sample/MyProject/aspnet-core/src/MyProject.Domain/"]
COPY ["src/EasyAbp.GiftCardManagement.Domain/EasyAbp.GiftCardManagement.Domain.csproj", "src/EasyAbp.GiftCardManagement.Domain/"]
COPY ["src/EasyAbp.GiftCardManagement.Application/EasyAbp.GiftCardManagement.Application.csproj", "src/EasyAbp.GiftCardManagement.Application/"]
COPY ["sample/MyProject/aspnet-core/src/MyProject.EntityFrameworkCore/MyProject.EntityFrameworkCore.csproj", "sample/MyProject/aspnet-core/src/MyProject.EntityFrameworkCore/"]
COPY ["src/EasyAbp.GiftCardManagement.EntityFrameworkCore/EasyAbp.GiftCardManagement.EntityFrameworkCore.csproj", "src/EasyAbp.GiftCardManagement.EntityFrameworkCore/"]
COPY ["src/EasyAbp.GiftCardManagement.Web/EasyAbp.GiftCardManagement.Web.csproj", "src/EasyAbp.GiftCardManagement.Web/"]
COPY Directory.Build.props .
RUN dotnet restore "sample/MyProject/aspnet-core/src/MyProject.Web/MyProject.Web.csproj"
COPY . .
WORKDIR "/src/sample/MyProject/aspnet-core/src/MyProject.Web"
RUN dotnet build "MyProject.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyProject.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyProject.Web.dll"]
