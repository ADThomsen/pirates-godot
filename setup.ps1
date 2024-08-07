$myName = Read-Host "Hvad er dit fornavn?"
New-Item -ItemType Directory -Path ./Racing/$myName -Force
New-Item -ItemType File -Path myName.txt -Force
Add-Content -Path myName.txt -Value $myName