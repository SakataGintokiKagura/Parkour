using UnityEngine;
using System.Collections;
using System;

public class Run : AbsState
{
    public Run(PlayerState player) : base(player)
    {
    }


    public override AbsState OnGrounded()
    {
        return player.run;
    }

    public override AbsState OnJump()
    {
        return player.first;
    }

    public override AbsState OnUseSkill(bool isInterrupted)
    {
        if (isInterrupted)
        {
            return player.general;
        }
        else
        {
            return player.unInterrupted;
        }
    }
}
