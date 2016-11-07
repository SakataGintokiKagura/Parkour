using UnityEngine;
using System.Collections;
using System;
using NPlayerState;

public class SkillRollAttack : IMeleeAttack
{
    public float damage
    {
        get
        {
            return 1.5f;
        }
    }

    public int MP
    {
        get
        {
            return 10;
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
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillRollAttack);
        state.OnUseSkill(true);
    }
}
