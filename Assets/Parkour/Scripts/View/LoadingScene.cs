using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadingScene : MonoBehaviour {

	public Slider processBar;
	private AsyncOperation async;
	private string URL_01;
	private string URL_02;
	void Start () {

		URL_01=
			#if UNITY_EDITOR
			"file://" + Application.dataPath + "/StreamingAssets/windows/";
			#elif UNITY_ANDROID
			"jar:file://" + Application.dataPath + "!/assets/Android/";
			#endif

		URL_02=
			#if UNITY_EDITOR
			Application.streamingAssetsPath+"/windows/";
			#elif UNITY_ANDROID
			"jar:file://" + Application.dataPath + "!/assets/Android/";
			#endif

		//AssetBundle assetBundle = AssetBundle.LoadFromFile(URL_02+"/test.assetbundle");

		AssetBundleManager.instance.loadAssetBundle (URL_02,"Table/tableDate");

		AssetBundleManager.instance.loadAssetBundle (URL_02,"Table/AssetBundleContent");

		StartCoroutine(loadAssetBundles());
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

			string[] temp_01 = path.Split('/');

			if (path != "1111"&&temp_01[0]!="Table") { 
				StartCoroutine (AssetBundleManager.instance.downLoadAssetBundleRequest (URL_01, path, name));
				yield return new WaitForSeconds (0.1f);
				continue;
			}
			else if(path != "1111"&&temp_01[0]=="Table"){
				AssetBundleManager.instance.loadAssetBundle (URL_02,path);
			}
			else if(path == "1111"){
				StartCoroutine(loadScene());  
				break;
			}
		}
	}

	IEnumerator loadScene()  
	{
		async = Application.LoadLevelAsync("Demo");  
		yield return async;  
	}
}
