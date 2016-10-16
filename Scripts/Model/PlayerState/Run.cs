using UnityEngine;
using System.Collections;
using System;

public class Run : IState
{
    public Run(PlayerState player) : base(player)
    {
    }

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
        return player.first;
    }
}
