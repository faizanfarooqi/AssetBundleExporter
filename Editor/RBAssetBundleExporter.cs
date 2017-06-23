using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using UnityEditor;

public class RBAssetBundleExporter {

	//we donot need these function as this is editor script being called without playmode
	// Use this for initialization
	/*void Start () {
		Debug.Log("start method called");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	*/

	/*
	Function to build asset bundles and export them to the specified directory
	Created by Faizan-ur-Rehman 
	Last updated 6/22/2017
	*/
	static void BuildAllAssetBundles ()
    {    	
		Debug.Log("Main script is started");
		string logFilePath = "C:\\Users\\Faizan\\Desktop\\assetBundleExporterLog.txt";
		string logText="In Editor script to export bundles";
		UnityEngine.Object[] resources;
		if(System.IO.Directory.Exists("C:\\Users\\Faizan\\Documents\\test\\Assets\\parrentResources")==false)
		{
			logText=logText+"\nPredefined path for resources in unity project (C:\\Users\\Faizan\\Documents\\test\\Assets\\parrentResources) does not exist";
			return;
		}
		string[] intermediateAddress=System.IO.Directory.GetDirectories("C:\\Users\\Faizan\\Documents\\test\\Assets\\parrentResources");
		if(intermediateAddress.Length!=1)
		{
			if(intermediateAddress.Length<1)
			{
				logText=logText+"\nFolder in parrentResources which must contain resources folder is not found.";
			}
			if(intermediateAddress.Length>1)
			{
				logText=logText+"\nThere exists more then one directories in parrentResources Folder. expecting 1";
			}
			File.WriteAllText(logFilePath, logText);	
			return;	
		}
		string uniqueFolderName=getFoldernameFromPath(intermediateAddress[0]);
		if(System.IO.Directory.Exists("C:\\Users\\Faizan\\Documents\\test\\Assets\\parrentResources\\"+uniqueFolderName+"\\Resources")==false)
		{
			logText=logText+"\nResources folder does not exist";
			File.WriteAllText(logFilePath, logText);
			return;
		}
		string[] resourceFolderNames=System.IO.Directory.GetDirectories("C:\\Users\\Faizan\\Documents\\test\\Assets\\parrentResources\\"+uniqueFolderName+"\\Resources");
		
		//Path exists. No assign asset bundles to all files corresponding to folder names
		foreach (var folderPath in  resourceFolderNames)
		{
			var folder=getFoldernameFromPath(folderPath);
			Debug.Log("folder name is "+folder);
			logText=logText+"\nfolder name is "+folder;
			resources = Resources.LoadAll(folder);

	        foreach (var r in resources)
	        {

	            Debug.Log("resource in folder "+folder+" is "+r.name);
	            logText=logText+"\nresource in folder "+folder+" is "+r.name;
	            Debug.Log(AssetDatabase.GetAssetPath(r));
	            string assetPath = AssetDatabase.GetAssetPath(r);
	         	AssetImporter.GetAtPath(assetPath).SetAssetBundleNameAndVariant(folder, "");

	        }
		}

        //Asset bundle names assigned. Now export bundles
        BuildPipeline.BuildAssetBundles("newAssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        //writing Log in manual file
		File.WriteAllText(logFilePath, logText);


	}
	
	/*
	Function that takes full absolute address and returns final folder name in the path
	Created by Faizan-ur-Rehman
	Last Updated 6/22/2017
	*/
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
