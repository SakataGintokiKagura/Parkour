using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour {

	public Slider processBar;

	private bool isLoading;

	private AsyncOperation async;

	private string URL_01;

	private string URL_02;

	private WWW www;

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

		AssetBundleManager.instance.loadAssetBundle (URL_02,"Table/tableDate");

		AssetBundleManager.instance.loadAssetBundle (URL_02,"Table/AssetBundleContent");

		ReadTable temp = ReadTable.getTable;

		for(int i = 1;;i++){

			string path=temp.OnFind("AssetBundleContent", i.ToString (), "Path");

			string name=temp.OnFind("AssetBundleContent", i.ToString (), "Name");

			string[] temp_01 = path.Split('/');

			if (path != "1111" && temp_01[0] != "Table")
			{
				StartCoroutine(AssetBundleManager.instance.loadAssetBundleRequest(URL_01, path, name));
				processBar.value = i /(float) 57;
			}
			else if (temp_01[0] == "Table")
			{
				AssetBundleManager.instance.loadAssetBundle(URL_02, path);
			}

			else if(path == "1111"){
				StartCoroutine(loadScene());  
				break;
			}
		}

	}  

	void Update(){
//		if (async != null)
//			processBar.value = async.progress;
	}

	IEnumerator loadScene()  
	{	 
		yield return new WaitForSeconds(2f);
		yield return SceneManager.LoadScene("Demo");
	}
		
}
	
