# Unzip deploy folder -- Install-Module -Name Posh-SSH
Write-Host "Remove AuthServiceEventServices.zip" -ForegroundColor DarkCyan
$Password = "sdl@1215"
$User = "sdlfly2000"
$ComputerNames = @("homeserver2")
$Command = 'sudo rm /home/sdlfly2000/Projects/AuthServiceEventServices/AuthServiceEventServices.zip'
$ExpectedString = "[sudo] password for " + $User + ":"

$secpasswd = ConvertTo-SecureString $Password -AsPlainText -Force
$Credentials = New-Object System.Management.Automation.PSCredential($User, $secpasswd)
foreach($ComputerName in $ComputerNames){
	$SessionID = New-SSHSession -ComputerName $ComputerName -Credential $Credentials #Connect Over SSH
	$stream = $SessionID.Session.CreateShellStream("PS-SSH", 0, 0, 0, 0, 1000)
	$result = Invoke-SSHStreamExpectSecureAction -ShellStream $stream -Command $Command -ExpectString $ExpectedString -SecureAction $secpasswd
	Write-Host "Remove AuthServiceEventServices.zip on $ComputerName : $result" -ForegroundColor DarkCyan
	$stream.Read()
}

