using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// 唐耀 技能规划，技能控制设计
/// 高攻近战
/// </summary>
public class SkillIaidoAttack : IMeleeAttack
{
    public float damage
    {
        get
        {
            return 4;
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

    public bool OnSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        throw new NotImplementedException();
    }

    public bool OnSkillAnimation(ref Vector3 velocity, Animator anim, PlayerState state)
    {
        throw new NotImplementedException();
    }

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        throw new NotImplementedException();
    }
}
