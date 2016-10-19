using UnityEngine;
using System.Collections;
using System;

public class FirstJump : AbsState
{
    public FirstJump(PlayerState player) : base(player)
    {
    }

    //public FirstJump(PlayerState player) {
    //    this.player = player;
    //}
    public override AbsState OnGrounded()
    {
        return player.run;
    }

    public override AbsState OnJump()
    {
        return player.second;
    }

    public override AbsState OnUseSkill(bool isInterrupted)
    {
        Debug.Log("状态出错");
        return this;
    }
}
