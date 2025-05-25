# Build EventServices
Write-Host "Building EventServices" -ForegroundColor DarkCyan
pushd ../AuthSserviceEventServices/
dotnet build --configuration release --output ../Artifacts/AuthServiceEventServices/
popd