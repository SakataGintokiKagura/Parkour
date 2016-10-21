using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

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
       
        //如果怪物出现在视野之中
        foreach (KeyValuePair<IBlology, GameObject> kv in monster)
        {
            if (Camera.main.WorldToViewportPoint(kv.Value.transform.position).x > 0 &&
                Camera.main.WorldToViewportPoint(kv.Value.transform.position).x < 1)
            {
                kv.Value.GetComponent<Animator>().SetBool("InView", true);
                if (kv.Value.transform.position.x - player.transform.position.x < kv.Key.normalAttackDistance &&
                    kv.Value.transform.position.x - player.transform.position.x > -1)
                {
                    kv.Value.GetComponent<Animator>().SetBool("Attack", true);
                    kv.Value.GetComponent<Animator>().SetBool("InView", false);
                    if (kv.Value.name == "Monster_Wasi(Clone)")
                    {
                        kv.Value.transform.FindChild("Monster_Wasi@skin").gameObject.SetActive(false);
                        kv.Value.transform.FindChild("Detonator-Simple").gameObject.GetComponent<Detonator>().enabled = true;
                        kv.Value.name = "Monster_Wasi";
                    }
                    if (kv.Value.name == "Monster_Dragon(Clone)")
                    {
                        (GameObject.Instantiate(sphere, kv.Value.transform.FindChild("sphere"), false) as GameObject).transform.position = kv.Value.transform.FindChild("sphere").position;
                        (GameObject.Instantiate(sphere, kv.Value.transform.FindChild("sphere"), false) as GameObject).transform.position = kv.Value.transform.FindChild("sphere").position + new Vector3(0.5f, 0, 0);
                        kv.Value.name = "Monster_Dragon";
                    }
                }

            }
            else if (Camera.main.WorldToViewportPoint(kv.Value.transform.position).x < 0)
            {
                outList.Add(kv.Value);
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

}
