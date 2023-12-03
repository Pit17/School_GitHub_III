@echo off
setlocal enabledelayedexpansion
cls 
set Input=false
set "Menu_Option="
set "Option1="
set "Option2="
set "Option3="
echo +===================================+
echo | Crea Cartella Con Data            |
echo +===================================+
echo |                                   |
echo | Dove desideri creare la cartella? |
echo |                                   |
echo | 1) Informatica                    |
echo |                                   |
echo | 2) TecnProg                       |
echo |                                   |
echo | 3) Sistemi e Reti                 |
echo |                                   |
echo +===================================+
set /p Menu_Option="Option: "
if %Menu_Option%==1 goto Informatica
if %Menu_Option%==2 goto TecnProg
if %Menu_Option%==3 goto Sistemi
if %Input%==false goto default

:Informatica
set input=true
REM Imposta il percorso desiderato
set "percorso=C:\Users\Utente\Desktop\1"

:TecnProg
set input=true
REM Imposta il percorso desiderato
set "percorso=C:\Users\Utente\Desktop\2"

:Sistemi
set input=true
REM
set "percorso=C:\Users\Utente\Desktop\3"

:default
echo Scelta non valida
timeout 2 > NUL



REM Ottieni la data corrente nel formato AAAA-MM-GG usando PowerShell
for /f "delims=" %%a in ('powershell -Command "Get-Date -Format 'yyyy-MM-dd'"') do set "data=%%a"

REM Crea la cartella
set "cartella=%percorso%\%data%"
powershell -Command "New-Item -ItemType Directory -Path '%cartella%'"

echo Cartella creata: %cartella%

endlocal