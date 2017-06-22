using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class modifiedAssetImporter : AssetPostprocessor {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 private void OnPreprocessModel()
	 {
	 	Debug.Log("on pre processor model function called");
	 	var importer = assetImporter as ModelImporter;
	 	importer.globalScale = 0.001f;
	 }
}
