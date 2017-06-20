using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAsset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var myLoadedAssetBundle = AssetBundle.LoadFromFile("C:\\Users\\Faizan\\Documents\\test\\newAssetBundles\\ceilinglight2");
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
        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("CeilingLight00");
        Debug.Log("loaded asset from bundle is " + prefab);
        Instantiate(prefab);

        var materialLoaded = myLoadedAssetBundle.LoadAsset<Material>("Line088Mat");
        MeshRenderer renderer = prefab.AddComponent<MeshRenderer>();
        prefab.GetComponent<MeshRenderer>().material=materialLoaded;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
