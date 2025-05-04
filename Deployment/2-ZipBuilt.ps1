# Zip the Artifacts
Write-Host "Zip Artifacts" -ForegroundColor DarkCyan
# Add-Type -AssemblyName System.IO.Compression.FileSystem 
# [System.IO.Compression.ZipFile]::CreateFromDirectory("../Artifacts/SimpleDashboard", "../Artifacts/SimpleDashboard.zip")
Compress-Archive -Path "../Artifacts/SimpleDashboard/*" -DestinationPath "../Artifacts/SimpleDashboard.zip" -Force