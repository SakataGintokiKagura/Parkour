using UnityEngine;
using System.Collections;
using System;
using NPlayerState;

public class SkillBigRollAttack : IMeleeAttack
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
            return 20;
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
        transform.localScale = new Vector3(1,1,1);
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
        transform.localScale = transform.localScale * 2;
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillBigRollAttack);
        state.OnUseSkill(false);
    }
}
