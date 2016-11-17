using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

public class MemoryController:MonoBehaviour{
	private bool[] isLoading;
	private static MemoryController _instance;
	private List <GameObject>[] memoryList;
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

	public GameObject OnFindGameObjectByName(string name,int serial,string path,string ID){
		
		foreach (var go in memoryList[(serial-1)])
		{
			if (go.name == ID)
			{
				go.SetActive(true);
				memoryList[serial-1].Remove(go);
				return go;    
			}
		}

		//Debug.Log (name);
		AssetBundleRequest abr = AssetBundleManager.instance.getAssetBundleRequest (path + name);
		GameObject fin = Instantiate (abr.asset)as GameObject;
		fin.name = ID;
		return fin;
	}

	public void OnListAddObject(GameObject go,int num)
	{
		go.SetActive (false);
		memoryList [num-1].Add (go);
	}
		
	public void deleteListObject(){

		while (Profiler.GetTotalAllocatedMemory () >= MemoryParameter.threshold) {

			for (int i = 0; i < MemoryParameter.objectType; i++) {

				if (memoryList [i].Count == 0&&i==MemoryParameter.objectType-1) 
					return;

				if (memoryList [i].Count == 0&&i!=MemoryParameter.objectType-1) 
					continue;

				else if (memoryList [i].Count != 0) {
					foreach (GameObject go in memoryList [i]){
						memoryList [i].Remove (go);
						GameObject.Destroy (go);
						return;
					}
				}
			}
		}
	}
}