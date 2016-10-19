using UnityEngine;
using System.Collections;
using System;

public class SkillRollAttack : IMeleeAttack
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
