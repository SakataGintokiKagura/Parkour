using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// 怪物的AI控制
/// </summary>
public class Monster : MonoBehaviour
{
    private IMonsterMediator monsterMediator;
    private Dictionary<IBlology, GameObject> monster;
    private List<GameObject> outList = new List<GameObject>();
    public GameObject player;
    private float initialPosition = 0;
    void Start()
    {
        monster = monsterMediator.monster;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - initialPosition > 600)
        {
            monsterMediator.OnCreateBoss();
            initialPosition = transform.position.x;
        }
        //如果怪物出现在视野之中
        foreach (KeyValuePair<IBlology, GameObject> kv in monster)
        {
            if (Camera.main.WorldToViewportPoint(kv.Value.transform.position).x > 0 &&
                Camera.main.WorldToViewportPoint(kv.Value.transform.position).x < 1.1)
            {
                kv.Key.OnInView(kv.Value.transform);
                if (kv.Value.transform.position.x - player.transform.position.x < kv.Key.normalAttackDistance &&
                    kv.Value.transform.position.x - player.transform.position.x > 0)
                {
                    kv.Key.OnAttack(kv.Value.transform);
                }
                else
                {
                    kv.Key.OnOutOfAttack(kv.Value.transform);
                }

            }
            //离开屏幕
            else if (Camera.main.WorldToViewportPoint(kv.Value.transform.position).x <0)
            {
                kv.Key.OnOutView(kv.Value.transform);
                outList.Add(kv.Value);
            }
//
//			for (int i = 0; i < MemoryController.instance.getMemoryList(ReadTable.getTable.OnFind("memoryObjectParameter","1","priority")).Count; i++)
//			{
//				GameObject go = MemoryController.instance.getMemoryList(ReadTable.getTable.OnFind("memoryObjectParameter","1","priority"))[i];
//				if (Camera.main.WorldToViewportPoint(go.transform.position).x < -0.1f)
//				{
//					MemoryController.instance.OnListAddObject (go, ReadTable.getTable.OnFind("memoryObjectParameter","1","priority"));
//					MemoryController.instance.OnRemoveObject (go,ReadTable.getTable.OnFind("memoryObjectParameter","1","priority"));
//				}
//			}
        }

        foreach (var temp in outList)
        {
            monsterMediator.OnDestroyMonster(temp);
        }
        outList.Clear();

       
    }

    public void OnSetMonsterMediator(IMonsterMediator monsterMediator)
    {
        this.monsterMediator = monsterMediator;
    }

    IEnumerator OnHideBoom(GameObject go)
    {
        yield return new WaitForSeconds(0.5f);
		if(go!= null)
        	go.SetActive(false);
    }
}
