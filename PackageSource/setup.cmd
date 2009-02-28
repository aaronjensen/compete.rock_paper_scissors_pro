@echo off

if [%1] == [] GOTO usage
if [%2] == [] GOTO usage

echo @Tools\Compete.Uploader.exe http://local.compete.com Source\RockPaperScissorsPro.Bot\bin\Debug\RockPaperScissorsPro.Bot.dll %1 %2 > upload.cmd

exit

:usage
echo Usage: setup.cmd {teamName} {password}
