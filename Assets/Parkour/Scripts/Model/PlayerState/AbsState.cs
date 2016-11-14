using UnityEngine;
using System.Collections;
using NPlayerState;

public abstract class AbsState
{
    protected PlayerState player;
    public AbsState(PlayerState player)
    {
        this.player = player;
    }
    public abstract AbsState OnJump();
    public abstract AbsState OnUseSkill(bool isInterrupted);
    public abstract AbsState OnGrounded();
}
