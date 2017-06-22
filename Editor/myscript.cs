using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;

public class myscript {

	// Use this for initialization
	/*void Start () {
		Debug.Log("start method called");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	*/

	
	static public void check()
	{
		UnityEngine.Debug.Log("check");
		FileStream F = new FileStream("C:\\Users\\Faizan\\Desktop\\test.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
         for (int i = 1; i <= 5; i++)
         {
            F.WriteByte((byte)i);
         }
         //BuildPipeline.BuildAssetBundles ("AssetBundles");
	}
	static void BuildAllAssetBundles ()
    {
    	UnityEngine.Debug.Log("check");
		FileStream F = new FileStream("C:\\Users\\Faizan\\Desktop\\test.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
         for (int i = 1; i <= 5; i++)
         {
            F.WriteByte((byte)i);
         }


    	Debug.Log("In asset build function");
 		//BuildPipeline.BuildAssetBundles("AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);  
 		//UnityEngine.Debug.Log(AssetDatabase.FindAssets(""));


    	/*
    	Debug.Log("Main script is started");
		UnityEngine.Object[] resources;
		resources = Resources.LoadAll("");

        foreach (var r in resources)
        {
            Debug.Log(r.name);
            Debug.Log(AssetDatabase.GetAssetPath(r));
            string assetPath = AssetDatabase.GetAssetPath(r);
         	AssetImporter.GetAtPath(assetPath).SetAssetBundleNameAndVariant("testBundle", "");
         	
        }
        BuildPipeline.BuildAssetBundles("newAssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
		*/

		//setting unity asset bundle names to none to export only assets set through resources
        
        /*var preResources = Resources.LoadAll("");

        foreach (var r in preResources)
        {
        	Debug.Log("asset in all resources is " + r);

            string preAssetPath = AssetDatabase.GetAssetPath(r);
         	AssetImporter.GetAtPath(preAssetPath).SetAssetBundleNameAndVariant("", "");
         }
         */

		Debug.Log("Main script is started");
		UnityEngine.Object[] resources;
		string[] intermediateAddress=System.IO.Directory.GetDirectories("C:\\Users\\Faizan\\Documents\\test\\Assets\\parrentResources");
		string uniqueFolderName=getFoldernameFromPath(intermediateAddress[0]);
		string[] resourceFolderNames=System.IO.Directory.GetDirectories("C:\\Users\\Faizan\\Documents\\test\\Assets\\parrentResources\\"+uniqueFolderName+"\\Resources");
		foreach (var folderPath in  resourceFolderNames)
		{
			var folder=getFoldernameFromPath(folderPath);
			Debug.Log("folder name is "+folder);

			//resources = Resources.LoadAll(getFoldernameFromPath(folder));
			resources = Resources.LoadAll(folder);

	        foreach (var r in resources)
	        {

	            Debug.Log("resource in folder "+folder+" is "+r.name);
	            Debug.Log(AssetDatabase.GetAssetPath(r));
	            string assetPath = AssetDatabase.GetAssetPath(r);
	         	AssetImporter.GetAtPath(assetPath).SetAssetBundleNameAndVariant(folder, "");

	        }
		}


		
        
        BuildPipeline.BuildAssetBundles("newAssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);


 		/*Process cmd = new Process();
		cmd.StartInfo.FileName = "cmd.exe";
		cmd.StartInfo.RedirectStandardInput = true;
		cmd.StartInfo.RedirectStandardOutput = true;
		cmd.StartInfo.CreateNoWindow = true;
		cmd.StartInfo.UseShellExecute = false;
		cmd.Start();

		cmd.StandardInput.WriteLine("echo \"hello\" ");
		cmd.StandardInput.Flush();
		cmd.StandardInput.Close();
		cmd.WaitForExit();
		Console.WriteLine(cmd.StandardOutput.ReadToEnd()); 
		*/ 
 	}


	public  static string getFoldernameFromPath(string a_address)
	{
		int lastHashIndex=0;
		for(int i=0;i<a_address.Length;i++)
		{
			if(a_address[i]=='\\')
			{
				lastHashIndex=i;
			}
		}
		string Foldername="";
		for(int i=lastHashIndex+1;i<a_address.Length;i++)
		{
			Foldername=Foldername+a_address[i];
		}
		return Foldername;
	}

}
