# Zip the Artifacts
Write-Host "Zip Artifacts" -ForegroundColor DarkCyan
Compress-Archive -Path "../Artifacts/AuthServiceEventServices/*" -DestinationPath "../Artifacts/AuthServiceEventServices.zip" -Force