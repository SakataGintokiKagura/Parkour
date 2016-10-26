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
                //瓦斯弹
                if (kv.Value.name == "Monster_Wasi(Clone)")
                {
                    kv.Value.GetComponent<Animator>().SetBool("InView", true);
                    if (kv.Value.transform.position.x - player.transform.position.x < kv.Key.normalAttackDistance &&
                        kv.Key.hasAttack == false)
                    {
                        kv.Key.hasAttack = true;
                        kv.Value.transform.FindChild("Monster_Wasi@skin").gameObject.SetActive(false);
                        kv.Value.transform.FindChild("Monster_Wasi@skin").position+=new Vector3(0,-500,0);
                        kv.Value.transform.FindChild("Boom").gameObject.SetActive(true);
                        StartCoroutine(OnHideBoom(kv.Value.transform.FindChild("Boom").gameObject));
                    }
                }
                //龙
                if (kv.Value.name == "Monster_Dragon(Clone)")
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
                if (kv.Value.name == "Monster_GuiKeBlue(Clone)")
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
                if (kv.Value.name == "Monster_Tianrenhua(Clone)")
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
            else if (Camera.main.WorldToViewportPoint(kv.Value.transform.position).x < 0)
            {
                kv.Key.hasAttack = false;
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

    IEnumerator OnHideBoom(GameObject go)
    {
        yield return new WaitForSeconds(0.5f);
        go.SetActive(false);
    }
}
