IF NOT EXIST "C:\Users\Faizan\Documents\test\Assets\" GOTO DIRECTORYNOTEXIST

::remove directory resource with all its sub directories and without confirmation

rmdir "C:\Users\Faizan\Documents\test\Assets\Resources" /s /q

rmdir "C:\Users\Faizan\Documents\test\Assets\parrentResources" /s /q

::create Resources directory in the new unique directory using build number environment variable

mkdir "C:\Users\Faizan\Documents\test\Assets\parrentResources\%BUILD_NUMBER%\Resources"

::unzip all input zip files to new created resource folder

IF NOT EXIST "C:\Program Files\7-Zip" GOTO 7ZIPNOTINSTALLED

cd "C:\Program Files\7-Zip"

IF NOT EXIST "C:\Users\Faizan\Desktop\input\" GOTO INPUTLOCATIONNOTFOUND

for %%i in ("C:\Users\Faizan\Desktop\input\*.zip") do 7z x %%i -oC:\Users\Faizan\Documents\test\Assets\parrentResources\%BUILD_NUMBER%\Resources

IF NOT EXIST "C:\Program Files\Unity\Editor\" GOTO UNITYNOTFOUND

cd "C:\Program Files\Unity\Editor"

::Now run unity in batch mode, unity project automatically detects new unique directory and create materials from .mtl files assign bundle names and export them(see the unity editor script)

start /wait Unity.exe -quit -projectPath "C:\Users\Faizan\Documents\test" -executeMethod RBAssetBundleExporter.BuildAllAssetBundles

if NOT %ERRORLEVEL%==0 ( exit /b 5)

::create folders for each bundle and copy files of same asset to its corresponging assets

IF NOT EXIST "C:\Users\Faizan\Documents\test\newAssetBundles\" GOTO OUTPUTFOLDERNOTEXISTS

cd "C:\Users\Faizan\Documents\test\newAssetBundles"

mkdir zips

::create folders

for %%i in (*.) do mkdir zips\%%i

::copy items

for %%i in (*.) do (for %%j in (%%i.*) do copy %%j zips\%%i\%%j)

cd "C:\Users\Faizan\Documents\test\newAssetBundles\zips"

for /d %%i in (*.*) do 7z a -tzip %%i %%i

GOTO END

:DIRECTORYNOTEXIST

echo "unity project directory does not exists. Please create unity project named test containing editer script myscript with function BuildAllAssetBundles which exports asset bundles folder wise from resources"

:7ZIPNOTINSTALLED

echo "7-zip is not installed. Please make sure that it is installed and in C:\Programm Files"
exit /b 1

:INPUTLOCATIONNOTFOUND

echo "Input location not found. place input zips in C:\users\faizan\desktop\input\"
exit /b 2

:UNITYNOTFOUND

echo "Unity is found in the system. please make sure it is installed and in the c:\program files"
exit /b 3

:OUTPUTFOLDERNOTEXISTS

echo "output folder not exists it should be in your unity project name newAssetBundles"
exit /b 4

:END

