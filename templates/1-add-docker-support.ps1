$templateRoot = "template-publish/content"
$templateSrc = "template-publish/content/src"
$temporaryProjectFolder = "RebornIdentityServer4Admin"
$templateDockerFolder = "template-docker"

# Remove original src folder for publish folder
if ((Test-Path -Path $templateSrc)) { Remove-Item ./$templateSrc -recurse -force }

# Copy new src folder
Copy-Item ./$temporaryProjectFolder/src ./$templateSrc -recurse -force
Copy-Item ./$temporaryProjectFolder/shared ./$templateRoot  -recurse -force
Copy-Item ./$temporaryProjectFolder/package ./$templateRoot  -recurse -force
Copy-Item ./$temporaryProjectFolder/.dockerignore ./$templateRoot  -recurse -force
Copy-Item ./$temporaryProjectFolder/docker-compose.dcproj ./$templateRoot  -recurse -force
Copy-Item ./$temporaryProjectFolder/docker-compose.override.yml ./$templateRoot  -recurse -force
Copy-Item ./$temporaryProjectFolder/docker-compose.vs.debug.yml ./$templateRoot  -recurse -force
Copy-Item ./$temporaryProjectFolder/docker-compose.vs.release.yml ./$templateRoot  -recurse -force
Copy-Item ./$temporaryProjectFolder/docker-compose.yml ./$templateRoot  -recurse -force
Copy-Item ./$temporaryProjectFolder/Directory.Build.props $templateRoot -recurse -force
Copy-Item ./$temporaryProjectFolder/LICENSE.md $templateRoot -recurse -force

# Copy docker files for Admin, Api and STS
Copy-Item ./$templateDockerFolder/RebornIdentityServer4Admin.Admin/* $templateSrc/RebornIdentityServer4Admin.Admin -recurse -force
Copy-Item ./$templateDockerFolder/RebornIdentityServer4Admin.Admin.Api/* $templateSrc/RebornIdentityServer4Admin.Admin.Api -recurse -force
Copy-Item ./$templateDockerFolder/RebornIdentityServer4Admin.STS.Identity/* $templateSrc/RebornIdentityServer4Admin.STS.Identity -recurse -force