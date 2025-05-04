# step Buid
./1-Build.ps1

# step Zip Buid
./2-ZipBuilt.ps1

# step Clean Up deployment folder
./3-CleanUpDeployFolder.ps1

# step Deploy zip file
./4-Deploy.ps1
Start-Sleep -Seconds 2

# step unzip file
./5-UnZip.ps1
Start-Sleep -Seconds 2

# step remove zip file
./6-RemoveZip.ps1
Start-Sleep -Seconds 2

# step remove image
./7-RemoveExistingDockerImage.ps1
Start-Sleep -Seconds 2

# step build image
./8-CreateDockerImage.ps1
Start-Sleep -Seconds 2

# step stop Container
./9-StopDockerContainer.ps1
Start-Sleep -Seconds 2

# step run Container
./10-RunDockerImage.ps1
Start-Sleep -Seconds 2