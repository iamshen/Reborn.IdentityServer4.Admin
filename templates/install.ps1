param([string] $packagesVersions, [string]$gitBranchName = 'master')

.\0-build-template.ps1 -packagesVersions $packagesVersions -gitBranchName $gitBranchName

# .\1-add-docker-support.ps1

.\2-publish-template.ps1 -packagesVersions $packagesVersions


# templating wiki https://github.com/dotnet/templating/wiki/Post-Action-Registry#existing-post-actions