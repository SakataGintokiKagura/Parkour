using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

public class MemoryController:MonoBehaviour{

	private bool[] isLoading;

	private static MemoryController _instance;

	private List <GameObject>[] memoryList;

	private string PathURL ;

	private string URL;

	private GameObject temp;

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

		//URL="jar:file://" + Application.dataPath + "!/assets/";
		URL="file://" + Application.dataPath + "/StreamingAssets/";
		//    	PathURL =Application.dataPath + "/StreamingAssets/";
		//		PathURL = Application.dataPath +"!assets/";

		memoryList=new List<GameObject>[MemoryParameter.objectType];

		for(int i=0;i<MemoryParameter.objectType;i++)
			memoryList [i] = new List<GameObject> ();
	}

	void Awake(){
		if(_instance==null)
			_instance = this;

	}

	void Update(){
		//Debug.Log (Profiler.GetTotalAllocatedMemory ());
		deleteListObject ();
	}

	public List<GameObject> getMemoryList(string num){
		return memoryList[(int.Parse(num))-1];
	}

	public GameObject OnFindGameObjectByName(string name,Vector3 position,string serial,string path,string load){

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

		//      AssetBundle bundle = AssetBundle.LoadFromFile(PathURL+path+name+".assetbundle");
		//		GameObject obj =Instantiate(bundle.LoadAsset(name) ,position,Quaternion.identity)as GameObject;
		//		bundle.Unload (false);

		MemoryController cb = MemoryController.instance;
		Type t =cb.GetType ();
		return (GameObject)t.InvokeMember (load,BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod,
	    null, cb, new object[] {name, position, serial, path });

	}

	public GameObject OnCreateTerrain(string name,Vector3 position,string serial,string path){
		return Instantiate(Resources.Load(path + name), position, Quaternion.identity) as GameObject;
	}

	public GameObject OnCreateProp(string name,Vector3 position,string serial,string path){
		return Instantiate(Resources.Load(path + name), position, Quaternion.identity) as GameObject;
	}

	public GameObject OnCreateFlyItem(string name,Vector3 position,string serial,string path){
		GameObject temp = Resources.Load(path + name) as GameObject;
		return Instantiate(temp, position, temp.transform.rotation)as GameObject;
	}

	public GameObject OnCreateMonster(string name,Vector3 position,string serial,string path){
		StartCoroutine (LoadAssetAsyncCoroutine (path, name, position, serial));
		return null;
	}

	public GameObject OnCreateCoin(string name,Vector3 position,string serial,string path){
		StartCoroutine (LoadAssetAsyncCoroutine (path, name, position, serial));
		return null;
	}

	public void OnAddObject(GameObject go,string num)
	{
		memoryList [(int.Parse(num))-1].Add (go);
	}

	public void OnRemoveObject(GameObject go,string num)
	{
		memoryList [(int.Parse(num)-1)].Remove (go);
	}


	public void deleteListObject(){
		while (Profiler.GetTotalAllocatedMemory () >= MemoryParameter.threshold) {
			for (int i = 0; i < MemoryParameter.objectType; i++) {
				if (memoryList [MemoryParameter.objectType - 1].Count == 0)
					return;
				if (memoryList [i].Count != 0) {
					foreach (GameObject go in memoryList [i])
					{
						Debug.Log (go.name);
						memoryList [i].Remove (go);
						GameObject.Destroy (go);
						return;
					}
				}
			}
		}
	}

	IEnumerator LoadAssetAsyncCoroutine(string path,string name, Vector3 position,string serial)
	{
		WWW www = new WWW(URL+path+name+".assetbundle");
		yield return www;
		while (isLoading[int.Parse(serial)-1]) {
			yield return new WaitForSeconds (0.06f);
		}
		isLoading [int.Parse (serial) - 1] = true;
		yield return temp = Instantiate(www.assetBundle.mainAsset,position,Quaternion.identity) as GameObject;
		OnReturn(path,temp);
		www.assetBundle.Unload (false);
		isLoading [int.Parse (serial) - 1] = false;
		www.Dispose();
		www = null;
	}

	private void OnReturn(string path,UnityEngine.Object @object)
	{
		if (path == "Monster/")
			MonsterMediator.OnGetMonsterMediator().OnAddMonster((GameObject)@object);
		if (path == "Coins/")
			TerrainMediator.OnGetTerrainMediator ().OnEnqueueOldCoin ((GameObject)@object);
	}
}

