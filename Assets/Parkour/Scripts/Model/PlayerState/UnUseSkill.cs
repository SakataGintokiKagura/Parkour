using System;
using UnityEngine;

namespace NPlayerState
{
    class UnUseSkill : AbsState
    {
        public UnUseSkill(PlayerState player) : base(player)
        {
        }
        /// <summary>
        /// 恢复使用技能状态
        /// </summary>
        /// <returns></returns>
        public override AbsState OnGrounded()
        {
            return null;
        }
        /// <summary>
        /// 开启不能使用技能状态
        /// </summary>
        /// <returns></returns>
        public override AbsState OnJump()
        {
            Debug.Log("机能状态出错");
            return this;
        }

        public override AbsState OnUseSkill(bool isInterrupted)
        {
            Debug.Log("机能状态出错");
            return this;
        }
    }
}
