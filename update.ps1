$myName = "skriv dit fornavn her"

New-Item -ItemType Directory -Path ./Racing/$myName -Force

git add ./Racing/$myName
git checkout .
git commit -m "Update"
git pull --rebase