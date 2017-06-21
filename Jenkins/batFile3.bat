::remove directory resource with all its sub directories and without confirmation

rmdir "C:\Users\Faizan\Documents\test\Assets\Resources" /s /q

rmdir "C:\Users\Faizan\Documents\test\Assets\parrentResources" /s /q

::create Resources directory in the new unique directory using build number environment variable

mkdir "C:\Users\Faizan\Documents\test\Assets\parrentResources\%BUILD_NUMBER%\Resources"

::unzip all input zip files to new created resource folder

cd "C:\Program Files\7-Zip"

for %%i in ("C:\Users\Faizan\Desktop\input\*.zip") do 7z x %%i -oC:\Users\Faizan\Documents\test\Assets\parrentResources\%BUILD_NUMBER%\Resources

::run unity project in batch mode so unity project automatically detects new unique directory and create materials from .mtl files

cd "C:\Program Files\Unity\Editor"

::Now run unity in batch mode, assign bundle names and export them(see the unity editor script)

start /wait Unity.exe -quit -projectPath "C:\Users\Faizan\Documents\test" -executeMethod myscript.BuildAllAssetBundles

::create folders for each bundle and copy files of same asset to its corresponging assets

cd "C:\Users\Faizan\Documents\test\newAssetBundles"

mkdir zips

::create folders

for %%i in (*.) do mkdir zips\%%i

::copy items

for %%i in (*.) do (for %%j in (%%i.*) do copy %%j zips\%%i\%%j)

cd "C:\Users\Faizan\Documents\test\newAssetBundles\zips"

for /d %%i in (*.*) do 7z a -tzip %%i %%i
