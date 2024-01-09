@echo off
setlocal enabledelayedexpansion
cls 



REM Imposta il percorso 
set "percorso=Z:\Informatica"


REM Ottieni la data corrente nel formato AAAA-MM-GG usando PowerShell
for /f "delims=" %%a in ('powershell -Command "Get-Date -Format 'yyyy-MM-dd'"') do set "data=%%a"

REM Crea la cartella
set "cartella=%percorso%\%data%"
powershell -Command "New-Item -ItemType Directory -Path '%cartella%'"


endlocal