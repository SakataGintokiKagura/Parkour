using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadingScene : MonoBehaviour {

	public Slider processBar;
	private AsyncOperation async;
	private bool a;
	void Start () {
		processBar.value = 0;
		a = false;
		StartCoroutine(loadScene());  
	}  

	void Update(){
		if (a) 
			processBar.value = (float)(async.progress);
		if (processBar.value == 0.9f)
			processBar.value += 0.1f;
	}

	IEnumerator loadScene()  
	{
//		yield return new WaitForSeconds (2f);
		a=true;
		async = Application.LoadLevelAsync("Demo");  
		yield return async;  
	}

//	IEnumerator loadAllAssetBundles(){
//		for(int i=0;i<MemoryParameter.objectType;i++){
//
//		}
//	}
}
