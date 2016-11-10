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

	public List<GameObject> getMemoryList(string num){
		return memoryList[(int.Parse(num))-1];
	}

	public GameObject OnFindGameObjectByName(string name,Vector3 position,string ID,ReturnObject returnObject){
		//string serial,string path,string load

		ReadTable temp = ReadTable.getTable;
		string serial = temp.OnFind ("memoryObjectParameter", ID, "priority");
		string path= temp.OnFind ("memoryObjectParameter", ID, "path");
		string load= temp.OnFind ("memoryObjectParameter", ID, "load");

		string nameClone = name + "(Clone)";
		foreach (var go in memoryList[(int.Parse(serial))-1])
		{
			if (go.name == nameClone)
			{
				go.transform.position = position;
				go.SetActive(true);
				memoryList[(int.Parse(serial))-1].Remove(go);
				return go;    
			}
		}
			
		Type t =GetType ();
		return (GameObject)t.InvokeMember (load,BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod,
			null, this, new object[] {name, position, serial, path,ID,returnObject});
	}


	public GameObject OnSynchronous(string name,Vector3 position,string serial,string path,string ID,ReturnObject returnObject){
		GameObject temp = Resources.Load(path + name) as GameObject;
		return Instantiate(temp, position, temp.transform.rotation)as GameObject;
	}

	public GameObject OnAsynchronous(string name,Vector3 position,string serial,string path,string ID,ReturnObject returnObject){
		StartCoroutine (LoadAssetAsyncCoroutine (path, name, position, serial,returnObject));
		return null;
	}

	public void OnListAddObject(GameObject go,string num)
	{
		go.SetActive (false);
		memoryList [(int.Parse(num))-1].Add (go);
	}

	public void OnRemoveObject(GameObject go,string num)
	{
		memoryList [(int.Parse(num)-1)].Remove (go);
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

	IEnumerator LoadAssetAsyncCoroutine(string path,string name, Vector3 position,string serial,ReturnObject returnObject){//ReturnObject action,
		WWW www = new WWW(URL+path+name+".assetbundle");
		yield return www;
		while (isLoading[int.Parse(serial)-1]) {
			yield return new WaitForSeconds (0.06f);
		}
		isLoading [int.Parse (serial) - 1] = true;
		AssetBundle assetbundle = www.assetBundle;
		AssetBundleRequest abr = assetbundle.LoadAssetAsync (name,typeof(GameObject));
		yield return abr;
		GameObject fin = Instantiate (abr.asset,position,Quaternion.identity)as GameObject;
		returnObject (fin);
		www.assetBundle.Unload (false);
		isLoading [int.Parse (serial) - 1] = false;
		www.Dispose();
	}

	public void emptyDelegate(GameObject @object){
		Debug.Log ("233");
	}
}

