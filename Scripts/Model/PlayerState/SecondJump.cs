using UnityEngine;
using System.Collections;
using System;

public class SecondJump : AbsState
{
    public SecondJump(PlayerState player) : base(player)
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
    public override AbsState OnUseSkill(bool isInterrupted)
    {
        Debug.Log("状态出错");
        return this;
    }
}
