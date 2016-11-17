using UnityEngine;
using System.Collections;
using System;

namespace CammerState
{
    public class MidCammerState : AbsGameState
    {

        public MidCammerState(GameStates gameState) : base(gameState)
        {

        }

        public override AbsGameState OnChangeWay(bool isNear)
        {
            if (isNear)
            {
                Debug.Log("从中到近");
                foreach (var item in gameState.gameStatesList)
                {
                    if (item is NearCammerState)
                    {
                        return item;
                    }
                    
                }
                return this;
            }
            else
            {
                Debug.Log("从中到远");
                foreach (var item in gameState.gameStatesList)
                {
                    if (item is FarCammerState)
                    {
                        return item;
                    }
                }
                
                return this;
            }
           
        }

        public override AbsGameState OnCreatBoss()
        {
            throw new System.NotImplementedException();
        }

        public override AbsGameState OnCancleBoss()
        {
            throw new System.NotImplementedException();
        }

        public override AbsGameState OnJudgeMonster(bool isCreate)
        {
            throw new NotImplementedException();
        }
    }

}
