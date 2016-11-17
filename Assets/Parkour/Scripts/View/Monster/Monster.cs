﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using CammerState;

/// <summary>
/// 怪物的AI控制
/// </summary>
public class Monster : MonoBehaviour
{
    private MonsterMediator monsterMediator;
    private Dictionary<IBlology, GameObject> monster;
    private List<GameObject> outList = new List<GameObject>();
    public GameObject player;
    private float initialPosition = 0;
    private GameStates gameStates;
    void Start()
	{
        gameStates = GameStates.getInstance;
		monsterMediator = MonsterMediator.OnGetMonsterMediator ();
		monsterMediator.monsterControl = this;
		monster = monsterMediator.monsterDic;
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.x - initialPosition > 10)
        //{
        //    if(gameStates.singleGameState is NearCammerState&&gameStates.shareGameStates is WithOutBossState)
        //    {
        //        monsterMediator.OnCreateBoss();
        //        initialPosition = transform.position.x;
        //    }
            
        //}
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
        }

        foreach (var temp in outList)
        {
            monsterMediator.OnDestroyMonster(temp);
        }
        outList.Clear();

       
    }
    IEnumerator OnHideBoom(GameObject go)
    {
        yield return new WaitForSeconds(0.5f);
		if(go!= null)
        	go.SetActive(false);
    }
}
