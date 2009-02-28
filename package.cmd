pushd ..\compete
call build.cmd
popd
copy ..\compete\source\compete.uploader\bin\debug\compete.uploader.exe PackageSource\Tools
copy ..\compete\source\compete.bot\bin\debug\compete.bot.dll PackageSource\Libraries
copy Source\RockPaperScissorsPro\bin\debug\RockPaperScissorsPro.dll PackageSource\Libraries
