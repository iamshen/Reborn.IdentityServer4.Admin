FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/RebornIdentityServer4Admin.STS.Identity/RebornIdentityServer4Admin.STS.Identity.csproj", "src/RebornIdentityServer4Admin.STS.Identity/"]
COPY ["src/RebornIdentityServer4Admin.Admin.EntityFramework.Shared/RebornIdentityServer4Admin.Admin.EntityFramework.Shared.csproj", "src/RebornIdentityServer4Admin.Admin.EntityFramework.Shared/"]
COPY ["src/RebornIdentityServer4Admin.Shared/RebornIdentityServer4Admin.Shared.csproj", "src/RebornIdentityServer4Admin.Shared/"]
RUN dotnet restore "src/RebornIdentityServer4Admin.STS.Identity/RebornIdentityServer4Admin.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/RebornIdentityServer4Admin.STS.Identity"
RUN dotnet build "RebornIdentityServer4Admin.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RebornIdentityServer4Admin.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "RebornIdentityServer4Admin.STS.Identity.dll"]