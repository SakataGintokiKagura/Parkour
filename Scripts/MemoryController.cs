using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MemoryController
{
    private static MemoryController _instance;
    /// <summary>
    /// 怪物容器 传声怪物的时候先从List中查找，如果找不到则重新新建一个怪物，在怪物死亡或者离开屏幕的时候加入这个容器
    /// </summary>
    public List<GameObject> monsterContainerList=new List<GameObject>();

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

    public void OnAddMonster(GameObject go)
    {
        monsterContainerList.Add(go);
    }
}
