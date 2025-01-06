@ECHO OFF
call :installProjectTemplate %~dp0BaseTemplate
pause
Exit


:installProjectTemplate
set TemplatePath=%~1
dotnet new -u %TemplatePath%
dotnet new -i %TemplatePath%
echo Das Template: %TemplatePath% wurde installiert.
EXIT /B 0