using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
/// <summary>
/// 怪物的AI控制
/// 张子庆
/// </summary>
public class Monster : MonoBehaviour
{
    private IMonsterMediator monsterMediator;
    private Dictionary<IBlology, GameObject> monster;
    public GameObject[] monsterPrefabs;
    private List<GameObject> outList = new List<GameObject>();
    public GameObject player;
    public GameObject sphere;
    private float initialPosition = 0;
    void Start()
    {
        monster = monsterMediator.monster;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - initialPosition > 400)
        {
            monsterMediator.OnCreateBoss();
            initialPosition = transform.position.x;
        }
        //如果怪物出现在视野之中
        foreach (KeyValuePair<IBlology, GameObject> kv in monster)
        {
            if (Camera.main.WorldToViewportPoint(kv.Value.transform.position).x > 0 &&
                Camera.main.WorldToViewportPoint(kv.Value.transform.position).x < 1)
            {
                //瓦斯弹
                if (kv.Value.name == "Gas(Clone)"|| kv.Value.name == "RedGas(Clone)" || kv.Value.name == "BlueGas(Clone)")
                {
                    kv.Value.GetComponent<Animator>().SetBool("InView", true);
                    if (kv.Value.transform.position.x - player.transform.position.x < kv.Key.normalAttackDistance &&
                        kv.Key.hasAttack == false)
                    {
                        kv.Key.hasAttack = true;
                        kv.Value.transform.FindChild("Monster_Wasi@skin").gameObject.SetActive(false);
                        kv.Value.transform.FindChild("Boom").gameObject.SetActive(true);
                        StartCoroutine(OnHideBoom(kv.Value.transform.FindChild("Boom").gameObject));
                    }
                }
                //龙
                if (kv.Value.name == "Dragon(Clone)")
                {
                    kv.Value.GetComponent<Animator>().SetBool("InView", true);
                    if (kv.Value.transform.position.x - player.transform.position.x < kv.Key.normalAttackDistance &&
                        kv.Key.hasAttack == false)
                    {
                        kv.Value.transform.FindChild("DragonWeapon").gameObject.SetActive(true);
                        kv.Key.hasAttack = true;
                    }
                }
                //龟壳
                if (kv.Value.name == "Tortoise(Clone)")
                {
                    kv.Value.GetComponent<Animator>().SetBool("InView", true);
                    if (kv.Value.transform.position.x - player.transform.position.x < kv.Key.normalAttackDistance &&
                        kv.Key.hasAttack == false)
                    {
                        kv.Key.hasAttack = true;
                        kv.Value.GetComponent<Animator>().SetBool("Attack", true);
                    }
                }
                //舔人花
                if (kv.Value.name == "Chomper(Clone)")
                {
                    kv.Value.GetComponent<Animator>().SetBool("InView", true);
                    if (kv.Value.transform.position.x - player.transform.position.x < kv.Key.normalAttackDistance &&
                        kv.Key.hasAttack == false)
                    {
                        kv.Key.hasAttack = true;
                        kv.Value.GetComponent<Animator>().SetBool("Attack", true);
                    }
                    else
                    {
                        kv.Value.GetComponent<Animator>().SetBool("Attack", false);
                    }
                    
                }
                

            }
            //离开屏幕
            else if (Camera.main.WorldToViewportPoint(kv.Value.transform.position).x < -0.1f)
            {
                if (kv.Value.name == "Gas(Clone)")
                {
                    kv.Value.GetComponent<Animator>().SetBool("InView", false);
                    kv.Value.transform.FindChild("Monster_Wasi@skin").gameObject.SetActive(true);
                }
                if (kv.Value.name == "Dragon(Clone)")
                {
                    kv.Value.transform.FindChild("DragonWeapon").gameObject.SetActive(false);
                    kv.Value.transform.FindChild("DragonWeapon").GetComponent<Rigidbody>().velocity=Vector3.zero;
                    kv.Value.transform.FindChild("DragonWeapon").gameObject.transform.localPosition=Vector3.zero;
                }
                if (kv.Value.name == "Tortoise(Clone)")
                {
                    kv.Value.GetComponent<Animator>().SetBool("InView", false);
                    kv.Value.GetComponent<Animator>().SetBool("Attack", false);
                }
                if (kv.Value.name == "Chomper(Clone)")
                {
                    kv.Value.GetComponent<Animator>().SetBool("InView", false);
                    kv.Value.GetComponent<Animator>().SetBool("Attack", false);
                }
                outList.Add(kv.Value);
            }

			for (int i = 0; i < MemoryController.instance.getMemoryList(ReadTable.getTable.OnFind("memoryObjectParameter","1","priority")).Count; i++)
			{
				GameObject go = MemoryController.instance.getMemoryList(ReadTable.getTable.OnFind("memoryObjectParameter","1","priority"))[i];
				if (Camera.main.WorldToViewportPoint(go.transform.position).x < -0.1f)
				{
					go.SetActive(false);
					MemoryController.instance.OnAddObject (go, ReadTable.getTable.OnFind("memoryObjectParameter","1","priority"));
					MemoryController.instance.OnRemoveObject (go,ReadTable.getTable.OnFind("memoryObjectParameter","1","priority"));
				}
			}
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
