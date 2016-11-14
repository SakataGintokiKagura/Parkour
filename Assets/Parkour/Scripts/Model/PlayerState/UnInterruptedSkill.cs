using UnityEngine;
using System;
namespace NPlayerState
{
    public class UnInterruptedSkill : AbsState
    {
        public UnInterruptedSkill(PlayerState player) : base(player)
        {
        }

        public override AbsState OnGrounded()
        {      
                return null;
        }

        public override AbsState OnJump()
        {
            foreach (var item in player.stateList)
            {
                if (item is UnUseSkill)
                {
                    return item;
                }
            }
            return null;
        }

        public bool OnSkillAnimation(ref Vector3 velocity, Animator anim, PlayerState state)
        {
            throw new NotImplementedException();
        }

        public override AbsState OnUseSkill(bool isInterrupted)
        {
            Debug.Log("状态出错");
            return this;
        }
    }
}
