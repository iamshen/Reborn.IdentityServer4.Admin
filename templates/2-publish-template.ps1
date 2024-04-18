param([string] $packagesVersions)

$templateNuspecPath = "template-publish/Reborn.IdentityServer4.Admin.Templates.nuspec"
nuget pack $templateNuspecPath -NoDefaultExcludes

dotnet.exe new --uninstall Reborn.IdentityServer4.Admin.Templates

$templateLocalName = "Reborn.IdentityServer4.Admin.Templates.$packagesVersions.nupkg"
dotnet.exe new -i $templateLocalName

dotnet.exe new reborn.is4admin --name MyProject --title MyProject --adminemail 'admin@email.com' --adminpassword 'Pa$$word123' --adminrole MyRole --adminclientid MyClientId --adminclientsecret MyClientSecret --dockersupport true