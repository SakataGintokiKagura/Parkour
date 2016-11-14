using UnityEngine;
using System.Collections;
using CammerState;

namespace CammerState
{

    public class FarCammerState : AbsGameState
    {
        public FarCammerState(GameStates gameState) : base(gameState)
        {
        }


        public override AbsGameState OnChangeWay(bool isNear)
        {
        
            foreach (var item in gameState.gameStatesList)
            {
                if (item is MidCammerState)
                {
                    return item;
                }
            }
            return this;
        }

        public override AbsGameState OnCreatBoss()
        {
            throw new System.NotImplementedException();
        }

        public override AbsGameState OnCancleBoss()
        {
            throw new System.NotImplementedException();
        }
    }

}
