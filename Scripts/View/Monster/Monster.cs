using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// 怪物的AI控制   张子庆
/// </summary>
public class Monster : MonoBehaviour
{
    private IMonsterMediator monsterMediator;
    private Dictionary<IBlology, GameObject> monster;
    public GameObject[] monsterPrefabs;
    private List<GameObject> monsterList = new List<GameObject>();
    private List<GameObject> outList = new List<GameObject>();
    public GameObject player;
    public GameObject sphere;
    void Start()
    {
        monster = monsterMediator.monster;
    }
    // Update is called once per frame
    void Update()
    {
       
        
        foreach (KeyValuePair<IBlology, GameObject> kv in monster)
        {
            //判断怪物是否进入屏幕视野之中 以及进入视野之后的动画控制
            if (Camera.main.WorldToViewportPoint(kv.Value.transform.position).x > 0 &&
                Camera.main.WorldToViewportPoint(kv.Value.transform.position).x < 1)
            {
                kv.Value.GetComponent<Animator>().SetBool("InView", true);
                //判断玩家是否进入怪物的攻击范围，如果进入攻击范围对玩家进行攻击
                if (kv.Value.transform.position.x - player.transform.position.x < kv.Key.normalAttackDistance &&
                    kv.Value.transform.position.x - player.transform.position.x > -1)
                {
                    kv.Value.GetComponent<Animator>().SetBool("Attack", true);
                    kv.Value.GetComponent<Animator>().SetBool("InView", false);
                    //瓦斯弹的AI
                    if (kv.Value.name == "Monster_Wasi(Clone)")
                    {
                        kv.Value.transform.FindChild("Monster_Wasi@skin").gameObject.SetActive(false);
                        kv.Value.transform.FindChild("Detonator-Simple").gameObject.GetComponent<Detonator>().enabled = true;
                        kv.Value.name = "Monster_Wasi";
                    }
                    //龙的AI
                    if (kv.Value.name == "Monster_Dragon(Clone)")
                    {
                        (GameObject.Instantiate(sphere, kv.Value.transform.FindChild("sphere"), false) as GameObject).transform.position = kv.Value.transform.FindChild("sphere").position;
                        (GameObject.Instantiate(sphere, kv.Value.transform.FindChild("sphere"), false) as GameObject).transform.position = kv.Value.transform.FindChild("sphere").position + new Vector3(0.5f, 0, 0);
                        kv.Value.name = "Monster_Dragon";
                    }
                }

            }
            //对进入屏幕视野的玩家离开屏幕的时候销毁
            else if (Camera.main.WorldToViewportPoint(kv.Value.transform.position).x < 0)
            {
                outList.Add(kv.Value);
            }
        }
        //对进入屏幕视野的玩家离开屏幕的时候销毁
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

}
