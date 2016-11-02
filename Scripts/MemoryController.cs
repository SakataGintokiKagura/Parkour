using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MemoryController:MonoBehaviour
{
    private static MemoryController _instance;

	private List <GameObject>[] memoryList;

	private string PathURL ;

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

		PathURL =
			#if UNITY_ANDROID
			"jar:file://" + Application.dataPath + "!/assets/";
			#elif UNITY_IPHONE
			Application.dataPath + "/Raw/";
			#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
			"file://" + Application.dataPath + "/StreamingAssets/";
			#else
			string.Empty;
			#endif
		
		memoryList=new List<GameObject>[MemoryParameter.objectType];

		for(int i=0;i<MemoryParameter.objectType;i++){
			memoryList [i] = new List<GameObject> ();
		}
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
			
		WWW bundle = new WWW (PathURL + path+name+".assetbundle"); 
		GameObject obj = GameObject.Instantiate(bundle.assetBundle.mainAsset,position,Quaternion.identity)as GameObject;
		bundle.assetBundle.Unload(false);

		//GameObject obj = GameObject.Instantiate(Resources.Load(path + name), position, Quaternion.identity) as GameObject;

		return obj;

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
}