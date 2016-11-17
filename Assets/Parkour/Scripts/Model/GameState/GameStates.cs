using System;
using UnityEngine;
using System.Collections;
using System.Reflection;
using CammerState;
using System.Collections.Generic;

namespace CammerState
{
    public class GameStates
    {
        private static GameStates instance;
        /// <summary>
        /// 当前的游戏状态
        /// </summary>
        public AbsGameState currentGameState;
        /// <summary>
        /// 单一状态
        /// </summary>
        public AbsGameState singleGameState;
        /// <summary>
        /// 共享状态 
        /// </summary>
        public AbsGameState[] shareGameStates= new AbsGameState[2];
        /// <summary>
        /// 状态数组
        /// </summary>
        public List<AbsGameState> gameStatesList=new List<AbsGameState>();


        public static GameStates getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance=new GameStates();
                   
                }
                return instance;
            }
        }
        public List<Type> GetTypes()
        {
            //Debug.Log(GetType());
            var lt = new List<Type>();
            try
            {
                foreach (var item in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if ((item.Namespace == GetType().Namespace) && (item != GetType()))
                    {
                        lt.Add(item);
                    }
                
                }
            }
            catch
            {

            }
            return lt;
        }
        private GameStates()
        {
            var ty = GetTypes();
            foreach (var item in ty)
            {
                gameStatesList.Add((AbsGameState)Activator.CreateInstance(item, this));
            }
            //Debug.Log(gameStatesList.Count);
            foreach (var item in gameStatesList)
            {
                if (item is MidCammerState)
                {
                    singleGameState = item;
                    //Debug.Log(singleGameState);
                }
                else if(item is WithOutBossState)
                {
                    shareGameStates[0] = item;
                    //Debug.Log(shareGameStates);
                }
                else if(item is CreateMonsterState)
                {
                    shareGameStates[1] = item;
                }
            }
        }

        public void OnSwitfRunWay(bool isNear)
        {   
            if (isNear)
            {
                singleGameState = singleGameState.OnChangeWay(true);
            }
            else
            {
                singleGameState = singleGameState.OnChangeWay(false);
            }
        }

        public void OnCreateBoss()
        {
            shareGameStates[0] = shareGameStates[0].OnCreatBoss();
            Debug.Log(shareGameStates);
        }

        public void OnCancleBoss()
        {
            shareGameStates[0] = shareGameStates[0].OnCancleBoss();
            Debug.Log(shareGameStates);
        }
        public void OnCreateMonster()
        {
            if(shareGameStates[1] is CreateMonsterState)
            {
                shareGameStates[1] = shareGameStates[1].OnJudgeMonster(false);
                Debug.Log("不生成怪物状态"+shareGameStates[1]);
            }
            else
            {
                shareGameStates[1] = shareGameStates[1].OnJudgeMonster(true);
                Debug.Log("生成怪物状态" + shareGameStates[1]);
            }
            
        }
    }

}