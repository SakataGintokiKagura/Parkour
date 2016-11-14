using UnityEngine;
using System.Collections;


namespace CammerState
{
    public class WithOutBossState : AbsGameState
    {
        public WithOutBossState(GameStates gameState) : base(gameState)
        {
        }

        public override AbsGameState OnChangeWay(bool isNear)
        {
            Debug.Log("不会出现这种状态的");
            return this;
        }

        public override AbsGameState OnCreatBoss()
        {
            foreach (var item in gameState.gameStatesList)
            {
                if (item is HaveBossState)
                {
                    return item;
                }
            }
            return this;
        }

        public override AbsGameState OnCancleBoss()
        {
            throw new System.NotImplementedException();
        }
    }

}
