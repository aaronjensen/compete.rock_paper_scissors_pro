@echo off

if [%1] == [] GOTO usage
if [%2] == [] GOTO usage
if [%3] == [] GOTO usage

echo @Tools\Compete.Uploader.exe http://%1 Source\RockPaperScissorsPro.Bot\bin\Debug\RockPaperScissorsPro.Bot.dll %2 %3 > upload.cmd

exit

:usage
echo Usage: setup.cmd {url} {teamName} {password}
