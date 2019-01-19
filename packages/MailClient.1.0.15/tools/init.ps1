param($installPath, $toolsPath, $package, $project)

#$PackageName = (Get-Project).ProjectName
$PackageName = "MailClient"
$update = Get-Package -Updates | Where-Object { $_.Id -eq $PackageName }
if ($update -ne $null -and $update.Version -gt $package.Version) {
    [System.Windows.Forms.MessageBox]::Show("New version $($update.Version) available for $($PackageName)") | Out-Null
}