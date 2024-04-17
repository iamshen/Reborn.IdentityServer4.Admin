param(
    [Parameter(Mandatory=$true, HelpMessage="请输入旧前缀，例如 'A.AspNetCore'")]
    [string]$oldPrefix,

    [Parameter(Mandatory=$true, HelpMessage="请输入新前缀，例如 'B.AspNetCore'")]
    [string]$newPrefix
)


# 使用脚本运行的位置作为根目录
$rootPath = $PSScriptRoot

# 获取所有以指定前缀开头的文件和文件夹，并按路径长度降序排序
$items = Get-ChildItem -Path $rootPath -Recurse | 
         Where-Object { $_.FullName -notmatch '\\bin\\' -and $_.FullName -notmatch '\\debug\\' -and $_.Name -like "$oldPrefix*" } |
         Sort-Object { $_.FullName.Length } -Descending

foreach ($item in $items) {
    # 构造新的文件或文件夹名
    $newName = $item.Name -replace "^$oldPrefix", $newPrefix
    
    # 确定新的路径
    if ($item.PSIsContainer) {
        $newPath = Join-Path -Path $item.Parent.FullName -ChildPath $newName
    } else {
        $newPath = Join-Path -Path $item.Directory.FullName -ChildPath $newName
    }
    
    # 检查$newPath是否不为空，并且原始路径确实存在
    if ($newPath -and (Test-Path -Path $item.FullName)) {
        try {
            # 尝试重命名文件或文件夹
            Rename-Item -Path $item.FullName -NewName $newName -ErrorAction Stop
        } catch {
            Write-Host "无法重命名文件: $item.FullName. 错误: $_"
        }
    } else {
        Write-Host "找不到文件或已被移动: $item.FullName"
    }
}

Write-Host "所有文件和文件夹已根据指定前缀 '$oldPrefix' 更改为 '$newPrefix'。"