﻿


using NPlayerState;
using System;
using UnityEngine;

class SkillInvicibleAuxiliary : IAuxiliary
{
    public float damage
    {
        get
        {
            return 0;
        }
    }

    public int MP
    {
        get
        {
            return 40;
        }
    }

    public float time
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public void OnEndSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        throw new NotImplementedException();
    }

    public int OnMiddleSkillAnimation()
    {
        throw new NotImplementedException();
    }

    public void OnMiddleSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        throw new NotImplementedException();
    }

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        state.OnUnHurt();
    }
}