# step Buid
./Build.ps1

# step Zip Buid
./ZipBuilt.ps1

# step Clean Up deployment folder
./CleanUpDeployFolder.ps1

# step Deploy zip file
./Deploy.ps1
Start-Sleep -Seconds 2

# step unzip file
./UnZip.ps1
Start-Sleep -Seconds 2

# step remove zip file
./RemoveZip.ps1
Start-Sleep -Seconds 2

# step remove image
./RemoveExistingDockerImage.ps1
Start-Sleep -Seconds 2

# step build image
./CreateDockerImage.ps1
Start-Sleep -Seconds 2

# step stop Container
./StopDockerContainer.ps1
Start-Sleep -Seconds 2

# step remove Container
./RemoveDockerContainer.ps1
Start-Sleep -Seconds 2

# step run Container
./RunDockerImage.ps1
Start-Sleep -Seconds 2