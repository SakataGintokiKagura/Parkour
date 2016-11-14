using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
	
public delegate void ReturnObject(GameObject obj);

public class MemoryController:MonoBehaviour{

	private bool[] isLoading;

	private static MemoryController _instance;

	private List <GameObject>[] memoryList;

	private string PathURL ;

	private string URL;

	private GameObject temp;
    /// <summary>
    /// 单例模式
    /// </summary>
	public static MemoryController instance
	{
		get
		{
			if (_instance==null)
				_instance=new MemoryController();
			return _instance;
		}
	}

	void Start(){ 
	    isLoading = new bool[MemoryParameter.objectType];
		URL=
		#if UNITY_EDITOR
		"file://" + Application.dataPath + "/StreamingAssets/windows/";
		#elif UNITY_ANDROID
		"jar:file://" + Application.dataPath + "!/assets/Android/";
		#endif
		memoryList=new List<GameObject>[MemoryParameter.objectType];
		for(int i=0;i<MemoryParameter.objectType;i++)
			memoryList [i] = new List<GameObject> ();
	}

	void Awake(){
		if(_instance==null)
			_instance = this;

	}

	void Update(){
		deleteListObject ();
	}

	public GameObject OnFindGameObjectByName(string name,Vector3 position,int serial,string path,string load,string ID,ReturnObject returnObject){

		foreach (var go in memoryList[serial-1])
		{
			if (go.name == ID)
			{
				go.transform.position = position;
				go.SetActive(true);
				memoryList[serial-1].Remove(go);
				return go;    
			}
		}
			
		Type t =GetType ();
		return (GameObject)t.InvokeMember (load,BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod,
			null, this, new object[] {name, position, serial, path,ID,returnObject});
	}


	public GameObject OnSynchronous(string name,Vector3 position,int serial,string path,string ID,ReturnObject returnObject){
		GameObject temp_01 = Resources.Load (path + name)as GameObject;
		GameObject temp_02 = Instantiate( temp_01, position, temp_01.transform.rotation)as GameObject ;
		temp_02.name = ID;
		return temp_02;
	}

	public GameObject OnAsynchronous(string name,Vector3 position,int serial,string path,string ID,ReturnObject returnObject){
		StartCoroutine (LoadAssetAsyncCoroutine (path, name, position, serial,ID,returnObject));
		return null;
	}

	public void OnListAddObject(GameObject go,int num)
	{
		go.SetActive (false);
		memoryList [num-1].Add (go);
	}
		
	public void deleteListObject(){
		while (Profiler.GetTotalAllocatedMemory () >= MemoryParameter.threshold) {
			for (int i = 0; i < MemoryParameter.objectType; i++) {
				if (memoryList [i].Count == 0&&i==MemoryParameter.objectType-1) {
					return;
				}
				if (memoryList [i].Count == 0&&i!=MemoryParameter.objectType-1) {
					continue;
				}
				else if (memoryList [i].Count != 0) {
					foreach (GameObject go in memoryList [i])
					{
						memoryList [i].Remove (go);
						GameObject.Destroy (go);
						return;
					}
				}
			}
		}
	}

	IEnumerator LoadAssetAsyncCoroutine(string path,string name, Vector3 position,int serial,string ID,ReturnObject returnObject){//ReturnObject action,
		WWW www = new WWW(URL+path+name+".assetbundle");
		yield return www;
		while (isLoading[serial-1]) {
			yield return new WaitForSeconds (0.06f);
		}
		isLoading [serial - 1] = true;
		AssetBundle assetbundle = www.assetBundle;
		AssetBundleRequest abr = assetbundle.LoadAssetAsync (name,typeof(GameObject));
		yield return abr;
		GameObject fin = Instantiate (abr.asset,position,Quaternion.identity)as GameObject;
		fin.name = ID;
		returnObject (fin);
		www.assetBundle.Unload (false);
		isLoading [serial - 1] = false;
		www.Dispose();
	}

	public void emptyDelegate(GameObject @object){
		Debug.Log ("233");
	}
}

