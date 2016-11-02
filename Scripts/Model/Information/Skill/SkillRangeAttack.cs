using UnityEngine;
using System.Collections;
using System;
using NPlayerState;

public class SkillRangeAttack : IMeleeAttack
{
    public float damage
    {
        get
        {
            return 2;
        }
    }
    public int MP
    {
        get
        {
            return 50;
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
        //Debug.Log(1111);
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillUnUse);
        state.OnEndSkill();
    }

    public int OnMiddleSkillAnimation()
    {
        throw new NotImplementedException();
    }

    public void OnMiddleSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        Debug.Log("技能过程出错");
    }
    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillRangeAttack);
        state.OnUseSkill(true);
    }
}
