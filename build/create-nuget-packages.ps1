$packagesOutput = ".\packages"

# Business Logic
dotnet pack .\..\src\Reborn.IdentityServer4.Admin.BusinessLogic\Reborn.IdentityServer4.Admin.BusinessLogic.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Reborn.IdentityServer4.Admin.BusinessLogic.Identity\Reborn.IdentityServer4.Admin.BusinessLogic.Identity.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Reborn.IdentityServer4.Admin.BusinessLogic.Shared\Reborn.IdentityServer4.Admin.BusinessLogic.Shared.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Reborn.IdentityServer4.Shared.Configuration\Reborn.IdentityServer4.Shared.Configuration.csproj -c Release -o $packagesOutput

# EF
dotnet pack .\..\src\Reborn.IdentityServer4.Admin.EntityFramework\Reborn.IdentityServer4.Admin.EntityFramework.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Reborn.IdentityServer4.Admin.EntityFramework.Extensions\Reborn.IdentityServer4.Admin.EntityFramework.Extensions.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Reborn.IdentityServer4.Admin.EntityFramework.Identity\Reborn.IdentityServer4.Admin.EntityFramework.Identity.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Reborn.IdentityServer4.Admin.EntityFramework.Shared\Reborn.IdentityServer4.Admin.EntityFramework.Shared.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Reborn.IdentityServer4.Admin.EntityFramework.Configuration\Reborn.IdentityServer4.Admin.EntityFramework.Configuration.csproj -c Release -o $packagesOutput

# UI
dotnet pack .\..\src\Reborn.IdentityServer4.Admin.UI\Reborn.IdentityServer4.Admin.UI.csproj -c Release -o $packagesOutput