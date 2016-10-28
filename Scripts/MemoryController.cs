using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MemoryController:MonoBehaviour
{
    private static MemoryController _instance;

    public List<GameObject> propInViewList=new List<GameObject>();
    /// <summary>
    /// 怪物容器 传声怪物的时候先从List中查找，如果找不到则重新新建一个怪物，在怪物死亡或者离开屏幕的时候加入这个容器
    /// </summary>
	private List<GameObject> monsterContainerList=new List<GameObject>();

	private List<GameObject> terrainContainerList=new List<GameObject>();

	private List<GameObject> coinContainerList=new List<GameObject>();
    
    public List<GameObject> propContainerList=new List<GameObject>();

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

	void Awake(){
		if(_instance==null)
			_instance = this;
	}
	void Update(){
		deleteListObject ();
	}

    /// <summary>
    /// 根据Name去查找并生成怪物
    /// </summary>
    /// <param name="name"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    public GameObject OnFindMonsterByName(string name,Vector3 position)
    {
        string nameClone = name + "(Clone)";
        foreach (var go in monsterContainerList)
        {
            if (go.name == nameClone)
            {
                go.transform.position = position;
                go.SetActive(true);
                monsterContainerList.Remove(go);
                return go;
                //break;
            }
        }
        
        GameObject monster = GameObject.Instantiate(Resources.Load("Monster/" + name), position
            , Quaternion.identity) as GameObject;

        return monster;
    }
    /// <summary>
    /// 根据Name查找并生成道具   
    /// </summary>
    /// <param name="name"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    public GameObject OnFindPropByName(string name, Vector3 position)
    {
        string nameClone = name + "(Clone)";
        foreach (var go in propContainerList)
        {
            if (go.name == nameClone)
            {
                go.transform.position = position;
                go.SetActive(true);
                propContainerList.Remove(go);
                return go;
            }
        }
        Debug.Log("道具容器里面没有找到道具");
        GameObject prop = GameObject.Instantiate(Resources.Load("Prop/" + name), position
            , Quaternion.identity) as GameObject;

        return prop;
    }
    /// <summary>
    /// 添加怪物进入怪物容器
    /// </summary>
    /// <param name="go"></param>
    public void OnAddMonster(GameObject go)
    {
        monsterContainerList.Add(go);
    }

	public GameObject OnFindTerrainByName(string name,Vector3 position)
	{
		string nameClone = name + "(Clone)";
		foreach (var go in terrainContainerList)
		{
			if (go.name == nameClone)
			{
				go.transform.position = position;
				go.SetActive(true);
				terrainContainerList.Remove(go);
				return go;
				//break;
			}
		}

		GameObject terrain = GameObject.Instantiate(Resources.Load("terrain/" + name), position
			, Quaternion.identity) as GameObject;

		return terrain;
	}

	public void OnAddTerrain(GameObject go)
	{
		terrainContainerList.Add(go);
	}

	public GameObject OnFindCoinByName(string name,Vector3 position)
	{
		string nameClone = name + "(Clone)";
		foreach (var go in coinContainerList)
		{
			if (go.name == nameClone)
			{
				go.transform.position = position;
				go.SetActive(true);
				coinContainerList.Remove(go);
				return go;
				//break;
			}
		}

		GameObject coin = GameObject.Instantiate(Resources.Load("Coins/" + name), position
			, Quaternion.identity) as GameObject;

		return coin;
	}

	public void OnAddCoin(GameObject go)
	{
		coinContainerList.Add(go);
	}

	public void deleteListObject(){
		while (Profiler.GetTotalAllocatedMemory () >= 78000000) {
			if (monsterContainerList.Count != 0) {
				foreach (GameObject go in monsterContainerList)
				{
					monsterContainerList.Remove (go);
					GameObject.Destroy (go);
					break;
				}
			} else if (coinContainerList.Count != 0) {
				foreach (GameObject go in coinContainerList)
				{
					coinContainerList.Remove (go);
					GameObject.Destroy (go);
					break;
				}
			} else if (terrainContainerList.Count != 0) {
				foreach (GameObject go in terrainContainerList)
				{
					terrainContainerList.Remove (go);
					GameObject.Destroy (go);
					break;
				}
			} else {
				return;
			}
		}
	}
    /// <summary>
    /// 添加道具
    /// </summary>
    /// <param name="go"></param>
    public void OnAddProp(GameObject go)
    {
        propContainerList.Add(go);
    }
		
}
