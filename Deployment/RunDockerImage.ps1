# Unzip deploy folder -- Install-Module -Name Posh-SSH
Write-Host "Run SimpleDashboard docker image" -ForegroundColor DarkCyan
$Password = "sdl@1215"
$User = "sdlfly2000"
$ComputerName = "homeserver"
$Command = 'sudo docker run -d --name SimpleDashboard -p 8080:80 -p 8443:443 simpledashboard:latest'
$ExpectedString = "[sudo] password for " + $User + ":"

$secpasswd = ConvertTo-SecureString $Password -AsPlainText -Force
$Credentials = New-Object System.Management.Automation.PSCredential($User, $secpasswd)
$SessionID = New-SSHSession -ComputerName $ComputerName -Credential $Credentials #Connect Over SSH
$stream = $SessionID.Session.CreateShellStream("PS-SSH", 0, 0, 0, 0, 1000)
$result = Invoke-SSHStreamExpectSecureAction -ShellStream $stream -Command $Command -ExpectString $ExpectedString -SecureAction $secpasswd
Write-Host "Run SimpleDashboard docker image: $result" -ForegroundColor DarkCyan
$stream.Read()

