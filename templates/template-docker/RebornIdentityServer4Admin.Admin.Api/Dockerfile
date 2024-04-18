FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/RebornIdentityServer4Admin.Admin.Api/RebornIdentityServer4Admin.Admin.Api.csproj", "src/RebornIdentityServer4Admin.Admin.Api/"]
COPY ["src/RebornIdentityServer4Admin.Admin.EntityFramework.Shared/RebornIdentityServer4Admin.Admin.EntityFramework.Shared.csproj", "src/RebornIdentityServer4Admin.Admin.EntityFramework.Shared/"]
COPY ["src/RebornIdentityServer4Admin.Admin.EntityFramework.SqlServer/RebornIdentityServer4Admin.Admin.EntityFramework.SqlServer.csproj", "src/RebornIdentityServer4Admin.Admin.EntityFramework.SqlServer/"]
COPY ["src/RebornIdentityServer4Admin.Shared/RebornIdentityServer4Admin.Shared.csproj", "src/RebornIdentityServer4Admin.Shared/"]
COPY ["src/RebornIdentityServer4Admin.Admin.EntityFramework.PostgreSQL/RebornIdentityServer4Admin.Admin.EntityFramework.PostgreSQL.csproj", "src/RebornIdentityServer4Admin.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/RebornIdentityServer4Admin.Admin.EntityFramework.MySql/RebornIdentityServer4Admin.Admin.EntityFramework.MySql.csproj", "src/RebornIdentityServer4Admin.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/RebornIdentityServer4Admin.Admin.Api/RebornIdentityServer4Admin.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/RebornIdentityServer4Admin.Admin.Api"
RUN dotnet build "RebornIdentityServer4Admin.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RebornIdentityServer4Admin.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "RebornIdentityServer4Admin.Admin.Api.dll"]