# 定义参数
Param(
    # Nuget APIKey
    [string] $apikey
)

if ($apikey -eq $null -or $apikey -eq "")
{
    # 请从配置中读取
    $apikey = "xxx"; 
}

$templateNuspec = "Reborn.IdentityServer4.Admin.Templates.nuspec"

# 加载 .nuspec 文件
[xml]$nuspec = Get-Content -Path $templateNuspec

# 从 .nuspec 文件中读取当前版本号
$currentVersion = $nuspec.package.metadata.version
$versionParts = $currentVersion.Split('.')

# 提取 major, minor, build 和 revision 部分
$major = $versionParts[0]
$minor = $versionParts[1]
$build = $versionParts[2]
$revision = [int]$versionParts[3]

# 计算新的 build 号，以 2024年1月1日为起点
$startDate = Get-Date "2024-01-01"
$today = Get-Date
$newBuild = ($today - $startDate).Days

# 如果 build 号发生变化，重置 revision 为 0，否则自增 revision
if ($newBuild -ne $build) {
    $build = $newBuild
    $revision = 0
} else {
    $revision++
}

# 组合新的版本号
$newVersion = "$major.$minor.$build.$revision"
# 更新 .nuspec 文件中的 version 节点
$nuspec.package.metadata.version = $newVersion
# 保存更改后的 .nuspec 文件
$nuspec.Save($templateNuspec)

# 从主分支克隆最新版本
$gitProject = "https://github.com/iamshen/Reborn.IdentityServer4.Admin"
git.exe clone --depth 1 $gitProject $gitProjectFolder -b master


# 接下来，打包 NuGet 包

$templateName = "templates"
$templateSrc =     "./$templateName/content/src"
$templateTests =     "./$templateName/content/tests"
$templateConfig =     "./$templateName/content/.template.config"
$contentDirectory = "./$templateName/content"

# Clean up src, tests, config folders
if ((Test-Path -Path $templateSrc)) { Remove-Item ./$templateSrc -recurse -force }
if ((Test-Path -Path $templateTests)) { Remove-Item ./$templateTests -recurse -force }
if ((Test-Path -Path $templateConfig)) { Remove-Item ./$templateConfig -recurse -force }
if ((Test-Path -Path $contentDirectory)) { Remove-Item ./$contentDirectory -recurse -force }

# Create src, tests, config folders
if (!(Test-Path -Path $templateSrc)) { mkdir $templateSrc }
if (!(Test-Path -Path $templateTests)) { mkdir $templateTests }
if (!(Test-Path -Path $templateConfig)) { mkdir $templateConfig }
 
Write-Output "Copy Project Template..."

# Copy the latest src and tests to content
Copy-Item ./$gitProjectFolder/src/* $templateSrc -recurse -force
Copy-Item ./$gitProjectFolder/tests/* $templateTests -recurse -force
Copy-Item ./$gitProjectFolder/.template.config/* $templateConfig -recurse -force

# Copy Solution Items
Copy-Item ./$gitProjectFolder/Directory.Build.props $contentDirectory -recurse -force
Copy-Item ./$gitProjectFolder/Reborn.IdentityServer4.Admin.sln $contentDirectory -recurse -force
Copy-Item ./$gitProjectFolder/Reborn.IdentityServer4.Admin.sln.DotSettings $contentDirectory -recurse -force
Copy-Item ./$gitProjectFolder/LICENSE.md $contentDirectory -recurse -force
Copy-Item ./$gitProjectFolder/README.md $contentDirectory -recurse -force

# Copy nuspec
Write-Output "Copy Template.nuspec..."
Copy-item -Force -Recurse "$templateNuspec" -Destination $contentDirectory


######################################
# Step 2
$templateNuspecPath = $contentDirectory/$templateNuspec
nuget pack $templateNuspecPath -NoDefaultExcludes
######################################
# Step 3
$project_nupkg = Get-ChildItem -Filter *.nupkg;
Write-Output "publish $project_nupkg to nuget.org..."

$nupkg = $project_nupkg.FullName;

Write-Output "-----------------";
$nupkg;

# Step 4
dotnet nuget push $nupkg --skip-duplicate --api-key $apikey --source https://api.nuget.org/v3/index.json;

Write-Output "-----------------";

Write-Output "finish publish $project_nupkg to nuget.org...";

Remove-Item $project_nupkg -Force -recurse

Remove-Item ./$gitProjectFolder -recurse -force

Write-Warning "发布成功";