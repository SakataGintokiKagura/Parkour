using UnityEngine;
using System.Collections;
using System;
namespace NPlayerState
{
    public class Run : AbsState
    {
        public Run(PlayerState player) : base(player)
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
            foreach (var item in player.stateList)
            {
                if (item is FirstJump)
                {
                    return item;
                }
            }
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
        }
    }
}
