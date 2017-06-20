rmdir "C:\Users\Faizan\Documents\test\Assets\Resources" /s /q

mkdir "C:\Users\Faizan\Documents\test\Assets\%BUILD_NUMBER%\Resources"

cd "C:\Program Files\7-Zip"

for %%i in ("C:\Users\Faizan\Desktop\input\*.rar") do 7z x %%i -oC:\Users\Faizan\Documents\test\Assets\%BUILD_NUMBER%\Resources

cd "C:\Program Files\Unity\Editor"

start /wait Unity.exe -quit -batchmode -projectPath "C:\Users\Faizan\Documents\test"

xcopy "C:\Users\Faizan\Documents\test\Assets\%BUILD_NUMBER%" "C:\Users\Faizan\Documents\test\Assets" /E

rmdir "C:\Users\Faizan\Documents\test\Assets\%BUILD_NUMBER%" /s /q

start /wait Unity.exe -quit -projectPath "C:\Users\Faizan\Documents\test" -executeMethod myscript.BuildAllAssetBundles
