cd "C:\Program Files\7-Zip"

for %%i in ("C:\Users\Faizan\Desktop\input\*.rar") do 7z x %%i -oC:\Users\Faizan\Documents\test\Assets\Resources

cd "C:\Users\Faizan\Documents\test\Assets\Resources"

for /r %%i in (*.mtl) do rename %%i *.txt

cd "C:\Program Files\Unity\Editor"

start /wait Unity.exe -quit -projectPath "C:\Users\Faizan\Documents\test" -executeMethod myscript.BuildAllAssetBundles
