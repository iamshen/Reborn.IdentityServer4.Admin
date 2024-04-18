# Clean up folders for template testing
$myProject = "MyProject"
$gitTemplateFolder = "RebornIdentityServer4Admin"

if ((Test-Path -Path $myProject)) { Remove-Item ./$myProject -recurse -force }
if ((Test-Path -Path $gitTemplateFolder)) { Remove-Item ./$gitTemplateFolder -recurse -force }