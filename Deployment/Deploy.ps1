# Common Function to Deploy Project
function UploadProject(){
	param(
	[string]$sourceFile,
	[string]$projectName,
	[string]$username = "sdlfly2000",
	[string]$password = "sdl@1215",
	[string]$urlDestination = "ftp://homeserver/Projects/SimpleDashboard"
	)
	$webclient = New-Object -TypeName System.Net.WebClient
	$webclient.Credentials = New-Object System.Net.NetworkCredential($username,$password)

	Write-Host "Uploading File: $sourceFile" -ForegroundColor DarkCyan
	$webclient.UploadFile("$urlDestination/SimpleDashboard.zip", $sourceFile)


    Write-Host "Uploading File: $sourceFile Successful" -ForegroundColor DarkCyan
	$webclient.Dispose()
}

# Upload AuthService - existing Directory
Write-Host "Uploading SimpleDashboard" -ForegroundColor DarkCyan
$source = "../Artifacts/SimpleDashboard.zip"
$projectName= "SimpleDashboard"

UploadProject -sourceFile $source -projectName $projectName