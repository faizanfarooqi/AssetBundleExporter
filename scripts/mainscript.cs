using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using System.IO;

public class mainscript : MonoBehaviour {

	public Object[] resources;
	// Use this for initialization
	void Start () {
		/*

		Debug.Log("Main script is started");
		 
		string[] resourceFolderNames=System.IO.Directory.GetDirectories("C:\\Users\\Faizan\\Documents\\test\\Assets\\Resources");
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
        */
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	string getFoldernameFromPath(string a_address)
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
