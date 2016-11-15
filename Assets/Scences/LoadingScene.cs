﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadingScene : MonoBehaviour {

	public Slider processBar;
	private AsyncOperation async;
	private string URL;
	void Start () {

		URL=
			#if UNITY_EDITOR
			"file://" + Application.dataPath + "/StreamingAssets/windows/";
			#elif UNITY_ANDROID
			"jar:file://" + Application.dataPath + "!/assets/Android/";
			#endif

		//StartCoroutine(loadAssetBundles());
		ReadTable temp = ReadTable.getTable;

		for(int i = 1;;i++){

			string path=temp.OnFind("AssetBundleContent", i.ToString (), "Path");
			string name=temp.OnFind("AssetBundleContent", i.ToString (), "Name");

			if (path != "1111") { 
			   StartCoroutine (AssetBundleManager.instance.downLoadAssetBundle (URL, path, name));
			}
			else {
				StartCoroutine(loadScene());  
				break;
			}
		}
	}  

	void Update(){
//		if (a) 
//			processBar.value = (float)(async.progress);
//		if (processBar.value == 0.9f)
//			processBar.value += 0.1f;
	}

	IEnumerator loadAssetBundles(){
		
		ReadTable temp = ReadTable.getTable;

		for(int i = 1;;i++){

			string path=temp.OnFind("AssetBundleContent", i.ToString (), "Path");
			string name=temp.OnFind("AssetBundleContent", i.ToString (), "Name");

			if (path != "1111") { 
				yield return StartCoroutine (AssetBundleManager.instance.downLoadAssetBundle (URL, path, name));
			}
			else {
				StartCoroutine(loadScene());  
				break;
			}
		}
	}

	IEnumerator loadScene()  
	{
		//yield return new WaitForSeconds (6f);
		async = Application.LoadLevelAsync("Demo");  
		yield return async;  
	}
}
