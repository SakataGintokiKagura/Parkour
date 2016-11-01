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
        foreach (var item in player.stateList)
        {
            if (item is Run)
            {
                return item;
            }
        }
        return this;
    }

    public override AbsState OnJump()
    {
        Debug.Log("状态出错");
        return this;
    }
    public override AbsState OnUseSkill(bool isInterrupted)
    {
        if (isInterrupted)
        {
            foreach (var item in player.stateList)
            {
                if (item is GeneralSkill)
                {
                    return item;
                }
            }
            return this;
        }
        else
        {
            foreach (var item in player.stateList)
            {
                if (item is UnInterruptedSkill)
                {
                    return item;
                }
            }
            return this;
        }
        return this;
    }
}
