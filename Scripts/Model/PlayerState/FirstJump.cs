using UnityEngine;
using System.Collections;
using System;

public class FirstJump : IState
{
    public FirstJump(PlayerState player) : base(player)
    {
    }

    //public FirstJump(PlayerState player) {
    //    this.player = player;
    //}

    public override IState OnAttack(bool isAttack)
    {
        throw new NotImplementedException();
    }

    public override IState OnGrounded()
    {
        return player.run;
    }

    public override IState OnJump(bool isJump)
    {
        return player.second;
    }
}
