@echo off
setlocal enabledelayedexpansion
cls 
echo 1) Informatica
echo 2) TecnProg
echo 3) Sistemi
choice Scegli: /c:123
if errorlevel 1 goto Informatica
if errorlevel 2 goto TecnProg
if errorlevel 3 goto Sistemi
echo numero non valido
:Informatica
REM Imposta il percorso desiderato
set "percorso=Z:\Informatica"
:TecnProg
REM Imposta il percorso desiderato
set "percorso=Z:\TecnProg"
:TecnProg
REM
set "percorso=Z:\Sistemi e Reti"




REM Ottieni la data corrente nel formato AAAA-MM-GG usando PowerShell
for /f "delims=" %%a in ('powershell -Command "Get-Date -Format 'yyyy-MM-dd'"') do set "data=%%a"

REM Crea la cartella
set "cartella=%percorso%\%data%"
powershell -Command "New-Item -ItemType Directory -Path '%cartella%'"

echo Cartella creata: %cartella%

endlocal