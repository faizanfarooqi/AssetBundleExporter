using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*
This class modifies the default property to import assets and sets the scale of each imported model to 0.001f
created by Faizan-ur-Rehman
Last Modified 22/6/2017
*/
public class RBAssetImporter : AssetPostprocessor {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*overrided function to modify default global scale
	created by Faizan-ur-Rehman
	Last Modified 22/6/2017
	*/
	 private void OnPreprocessModel()
	 {
	 	Debug.Log("on pre processor model function called");
	 	var importer = assetImporter as ModelImporter;
	 	importer.globalScale = 0.001f;
	 }
}
