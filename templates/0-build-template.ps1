param([string] $packagesVersions, [string]$gitBranchName = 'master')

# This script contains following steps:
# - 从 git 仓库下载 Reborn.IdentityServer4.Admin 的最新版本
# - 项目模板使用 src 和 tests 文件夹
# - 为 EF Core 种子数据创建数据库迁移

$gitProject = "https://gitee.com/gold-cloud/reborn-identity-server4-admin"
$gitProjectFolder = "Reborn.IdentityServer4.Admin"
$templateRoot = "template-build/content"
$templateSrc = "template-build/content/src"
$templateTests = "template-build/content/tests"
$templateAdminProject = "template-build/content/src/Reborn.IdentityServer4.Admin"

function CleanBinObjFolders { 

    # Clean up after migrations
    dotnet.exe clean $templateAdminProject

    # Clean up bin, obj
    Get-ChildItem .\ -include bin, obj -Recurse | ForEach-Object ($_) { Remove-Item $_.fullname -Force -Recurse }    
}


# 从主分支克隆最新版本
git.exe clone --depth 1 $gitProject $gitProjectFolder -b $gitBranchName

# 清理 src、tests 文件夹
if ((Test-Path -Path $templateSrc)) { Remove-Item ./$templateSrc -recurse -force }
if ((Test-Path -Path $templateTests)) { Remove-Item ./$templateTests -recurse -force }

# 创建 src、tests 文件夹
if (!(Test-Path -Path $templateSrc)) { mkdir $templateSrc }
if (!(Test-Path -Path $templateTests)) { mkdir $templateTests }

# 将最新的 src 和 tests 内容复制到内容中
Copy-Item ./$gitProjectFolder/src/* $templateSrc -recurse -force  -Exclude 'node_modules', 'bin', 'obj'
Copy-Item ./$gitProjectFolder/tests/* $templateTests -recurse -force  -Exclude 'node_modules', 'bin', 'obj'

# 复制其他文件
Copy-Item ./$gitProjectFolder/shared $templateRoot -recurse -force
Copy-Item ./$gitProjectFolder/package $templateRoot -recurse -force
Copy-Item ./$gitProjectFolder/LICENSE.md $templateRoot -recurse -force

Copy-Item ../Directory.Build.props $templateRoot -recurse -force

# 清理创建的临时文件夹
Remove-Item ./$gitProjectFolder -recurse -force

# 清理解决方案和文件夹 bin、obj
CleanBinObjFolders

######################################
# Step 2
Write-Host "打包项目模板成一个 NuGet 包"
$templateNuspecPath = "template-build/Reborn.IdentityServer4.Admin.Templates.nuspec"
nuget pack $templateNuspecPath -NoDefaultExcludes

#####################################
# Step 3
Write-Host "卸载，然后安装新版本项目模板 Reborn.IdentityServer4.Admin.Templates"
$templateLocalName = "Reborn.IdentityServer4.Admin.Templates.$packagesVersions.nupkg"

dotnet.exe new uninstall Reborn.IdentityServer4.Admin.Templates
dotnet.exe new install $templateLocalName

#####################################
# Step 4
Write-Host "创建用于固定项目名称的模板"
dotnet new reborn.is4admin --name SampleIdentityServer --title "Sample IdentityServer4 Admin" --adminrole Administrator --adminclientid sample_identity_admin --adminclientsecret sample_admin_client_secret --force

