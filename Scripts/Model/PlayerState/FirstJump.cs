using UnityEngine;
using System.Collections;
using System;

public class FirstJump : StateInterfance
{
    public FirstJump(PlayerState player) : base(player)
    {
    }

    //public FirstJump(PlayerState player) {
    //    this.player = player;
    //}

    public override StateInterfance OnAttack(bool isAttack)
    {
        throw new NotImplementedException();
    }

    public override StateInterfance OnGrounded()
    {
        return player.run;
    }

    public override StateInterfance OnJump(bool isJump)
    {
        return player.second;
    }
}
