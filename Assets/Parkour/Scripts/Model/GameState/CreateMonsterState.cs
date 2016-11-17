using UnityEngine;
using System.Collections;
using System;

namespace CammerState
{
    public class CreateMonsterState : AbsGameState
    {
        public CreateMonsterState(GameStates gameState) : base(gameState)
        {
        }

        public override AbsGameState OnCancleBoss()
        {
            throw new NotImplementedException();
        }

        public override AbsGameState OnChangeWay(bool isNear)
        {
            throw new NotImplementedException();
        }

        public override AbsGameState OnCreatBoss()
        {
            throw new NotImplementedException();
        }

        public override AbsGameState OnJudgeMonster(bool isCreateMonster)
        {
            if (isCreateMonster)
            {
                foreach (var item in gameState.gameStatesList)
                {
                    if (item is CreateMonsterState)
                    {
                        return item;
                    }
                }
            }
            else
            {
                return null;
            }
           
            return this;
        }

    }

}
