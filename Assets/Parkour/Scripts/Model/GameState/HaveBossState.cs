using UnityEngine;
using System.Collections;


namespace CammerState
{
    public class HaveBossState : AbsGameState
    {
        public HaveBossState(GameStates gameState) : base(gameState)
        {
        }

        public override AbsGameState OnChangeWay(bool isNear)
        {
            Debug.Log("不会出现这种状态的");
            return this;
        }

        public override AbsGameState OnCreatBoss()
        {
            throw new System.NotImplementedException();
        }

        public override AbsGameState OnCancleBoss()
        {
            foreach (var item in gameState.gameStatesList)
            {
                if (item is WithOutBossState)
                {
                    return item;
                }
            }
            return this;
        }
    }

}
