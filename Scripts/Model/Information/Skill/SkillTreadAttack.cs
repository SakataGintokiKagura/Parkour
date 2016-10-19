using UnityEngine;
using System.Collections;
using System;

public class SkillTreadAttack : ISkill
{
    public float damage
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public int MP
    {
        get
        {
            throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}
