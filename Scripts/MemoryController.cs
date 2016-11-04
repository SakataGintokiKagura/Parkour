using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class MemoryController:MonoBehaviour{
    
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
            {
                _instance=new MemoryController();
            }
            return _instance;
        }
    }

	void Start(){ 
		URL="file://" + Application.dataPath + "/StreamingAssets/";
    	PathURL =Application.dataPath + "/StreamingAssets/";
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
		deleteListObject ();
	}

	public List<GameObject> getMemoryList(string num){
		return memoryList[(int.Parse(num))-1];
	}

	public GameObject OnFindGameObjectByName(string name,Vector3 position,string serial,string path){

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
        //AssetBundle bundle = AssetBundle.LoadFromFile(PathURL+path+name+".assetbundle");
        if (path == "Monster/")
            StartCoroutine(LoadAssetAsyncCoroutine(path, name, position));

        //		GameObject obj =Instantiate(bundle.LoadAsset(name) ,position,Quaternion.identity)as GameObject;
        //
        //		bundle.Unload (false);

        if (path != "Monster/")
            return Instantiate(Resources.Load(path + name), position, Quaternion.identity) as GameObject;
        else
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
						memoryList [i].Remove (go);
						GameObject.Destroy (go);
						return;
					}
				}
			}
		}
	}
	void OnReturn(string path,UnityEngine.Object asset, Vector3 position,string name)
    {
        if(path == "Monster/")
        {
            GameObject monster = Instantiate(asset
               , position, Quaternion.identity) as GameObject;
            //MonsterMediator.OnGetMonsterMediator().OnAddMonster(monster);
        }
    }

	IEnumerator LoadAssetAsyncCoroutine(string path,string name, Vector3 position)
	{
        WWW www = new WWW(URL+name+".assetbundle");
        yield return www;
		yield return temp = Instantiate(www.assetBundle.mainAsset,position,Quaternion.identity) as GameObject;
        OnReturn(temp);
		www.assetBundle.Unload (false);
        www.Dispose();
        www = null;
    }

    private void OnReturn(UnityEngine.Object @object)
    {
        MonsterMediator.OnGetMonsterMediator().OnAddMonster((GameObject)@object);
    }
}
