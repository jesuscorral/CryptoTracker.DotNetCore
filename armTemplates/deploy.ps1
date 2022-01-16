$rg = 'CryptoTracker.Dev'
$adminUser = Read-Host -Prompt "Enter the SQL server administrator username"
$adminPassword = Read-Host -Prompt "Enter the SQl server administrator password" -AsSecureString

New-AzureRmResourceGroup -Name $rg -Location northeurope -Force

New-AzureRmResourceGroupDeployment `
    -Name 'crypto-tracker-dev-sdb' `
    -ResourceGroupName $rg `
    -TemplateFile '01-sql-server.json' `
    -userSqlServer $adminUser `
    -passwordSqlServer $adminPassword

