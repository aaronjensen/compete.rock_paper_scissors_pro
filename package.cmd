pushd ..\compete
call build.cmd
popd
copy ..\compete\source\compete.uploader\bin\debug\compete.uploader.exe PackageSource\Tools
copy ..\compete\source\compete.bot\bin\debug\compete.bot.dll PackageSource\Libraries
copy Source\RockPaperScissorsPro.Round1\bin\debug\RockPaperScissorsPro.Round1.dll PackageSource\Libraries

del /s /q Packages
mkdir Packages

pushd PackageSource
call git clean -d -f
..\Tools\zip.exe -r ..\Packages\Round1.zip *
popd
pushd Source\RockPaperScissorsPro.Round3\bin\debug
..\..\..\..\Tools\zip.exe ..\..\..\..\Packages\Round2.zip RockPaperScissorsPro.Round2.dll
..\..\..\..\Tools\zip.exe ..\..\..\..\Packages\Round3.zip RockPaperScissorsPro.Round3.dll
popd
