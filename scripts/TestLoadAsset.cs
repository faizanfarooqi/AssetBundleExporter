using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script is for loading asset from specified asset bundle and is just for testing assets in unity
*/
public class TestLoadAsset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//var myLoadedAssetBundle = AssetBundle.LoadFromFile("C:\\Users\\Faizan\\Documents\\test\\newAssetBundles\\ceilinglight2");
        //var myLoadedAssetBundle = AssetBundle.LoadFromFile("C:\\Users\\Faizan\\Documents\\test\\manualAssetBundles\\testbundle");
        var myLoadedAssetBundle = AssetBundle.LoadFromFile("C:\\Users\\Faizan\\Documents\\test\\allAssetBundlesUnzipped\\kensingtonleathersofa2010_unity");
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        Debug.Log("loaded asset bundle is " + myLoadedAssetBundle);
		Object[] allAssets=myLoadedAssetBundle.LoadAllAssets();        
		foreach (var asset in allAssets)
		{
			Debug.Log("asset in this bundle is " + asset);
		}
        //var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("CeilingLight00");
        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("kensingtonleathersofa2010.obj");
        if(prefab == null)
        {
        	Debug.Log("object not loaded from bundle");
        	return;
        }
        Debug.Log("loaded asset from bundle is " + prefab);
        Instantiate(prefab);

        //var materialLoaded = myLoadedAssetBundle.LoadAsset<Material>("Line088Mat");
        //MeshRenderer renderer = prefab.AddComponent<MeshRenderer>();
        //prefab.GetComponent<MeshRenderer>().material=materialLoaded;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
