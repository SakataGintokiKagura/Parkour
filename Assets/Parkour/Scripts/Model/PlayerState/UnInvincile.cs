using System;
using UnityEngine;

namespace NPlayerState
{
    public class UnInvincile : AbsState
    {
        public UnInvincile(PlayerState player) : base(player)
        {
        }
        /// <summary>
        /// 停止无敌状态
        /// </summary>
        /// <returns></returns>
        public override AbsState OnGrounded()
        {
            Debug.Log("状态出错");
            return this;
        }
        /// <summary>
        /// 开始无敌状态
        /// </summary>
        /// <returns></returns>
        public override AbsState OnJump()
        {
            foreach (var item in player.stateList)
            {
                if (item is Invincible)
                {
                    return item;
                }
            }
            return this;
        }

        public override AbsState OnUseSkill(bool isInterrupted)
        {
            Debug.Log("状态出错");
            return this;
        }
    }
}

