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
        public static GameStates instance;
        /// <summary>
        /// 单一状态
        /// </summary>
        public AbsGameState singleGameState;
        /// <summary>
        /// 共享状态 
        /// </summary>
        public AbsGameState shareGameStates;
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
           // Debug.Log(lt.Count);
            return lt;
        }
        private GameStates()
        {
//            var ty = GetTypes();
//            foreach (var item in ty)
//                stateList.Add((AbsState)Activator.CreateInstance(item, this));
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
                    shareGameStates = item;
                    //Debug.Log(shareGameStates);
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
            shareGameStates = shareGameStates.OnCreatBoss();
            Debug.Log(shareGameStates);
        }

        public void OnCancleBoss()
        {
            shareGameStates = shareGameStates.OnCancleBoss();
            Debug.Log(shareGameStates);
        }
       
    }

}