@echo off
setlocal

set "ROOT=C:\Users\ak\OneDrive\VSProje\FiloGH"
set "OUT=%ROOT%\_context"
set "PROJ=C:\Users\ak\OneDrive\VSProje\ContextBundler\ContextBundler.csproj"

if not exist "%OUT%" mkdir "%OUT%"

echo Running ContextBundler...
dotnet run --project "%PROJ%" -- -r "%ROOT%" -o "%OUT%" -includeCode true -maxCodeBytes 500000
if %ERRORLEVEL%==0 (
  echo Done. Opening output folder...
  explorer "%OUT%"
) else (
  echo Hata! ExitCode=%ERRORLEVEL%
  pause
)

endlocal
