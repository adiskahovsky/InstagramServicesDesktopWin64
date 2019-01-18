param($installPath, $toolsPath, $package, $project)
$project.ProjectItems.Item("MailClient.dll").Properties.Item("CopyToOutputDirectory").Value = 1
#$PackageName = (Get-Project).ProjectName
$PackageName = "MailClient"

$message = "You have added "+ $PackageName + ".dll package"
$message += "`n"
$message += "Please contact me for any issue:"
$message += "`n"
$message += "Email: sagi.baron76@gmail.com"
$message += "`n"
$message += "Skype: sagi.bar.on"
$message += "`n"
$message += "Twitter: @sagibaron"
$message += "`n"
$message += "WEB: https://code.google.com/p/sagibo-mailclient"

################################################################################################
# WinForm generation for prompt
################################################################################################
[System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms")
[Windows.Forms.MessageBox]::Show($message, "Finish Instalation", [Windows.Forms.MessageBoxButtons]::OK, [Windows.Forms.MessageBoxIcon]::Information)