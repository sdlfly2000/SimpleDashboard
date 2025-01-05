# Build Presentation.Web.Angular
Write-Host "Building Presentation.Web.Angular" -ForegroundColor DarkCyan
pushd ../Presentation.Web.Angular/
ng build --output-path ../Artifacts/SimpleDashboard/wwwroot
popd

# Build AuthService
Write-Host "Building SimpleDashboard" -ForegroundColor DarkCyan
pushd ../Presentation.WebApi/
dotnet build --configuration release --output ../Artifacts/SimpleDashboard/
popd

# Copy Dockerfile
Write-Host "Copy Dockerfile" -ForegroundColor DarkCyan
cp ./Dockerfile ../Artifacts/SimpleDashboard/
popd