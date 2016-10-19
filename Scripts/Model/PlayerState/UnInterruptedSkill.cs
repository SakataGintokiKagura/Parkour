using UnityEngine;
using System;

public class UnInterruptedSkill : AbsState
{
    public UnInterruptedSkill(PlayerState player) : base(player)
    {
    }

    public override AbsState OnGrounded()
    {
        return player.run;
    }

    public override AbsState OnJump()
    {
        Debug.Log("状态出错");
        return this;
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
