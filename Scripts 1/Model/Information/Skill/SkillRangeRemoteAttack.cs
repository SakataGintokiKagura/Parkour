using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// 唐耀 技能规划，技能控制设计
/// 范围远程攻击
/// </summary>
public class SkillRangeRomateAttack : ISkill
{
    public float damage
    {
        get
        {
            return 0.5f;
        }
    }

    public int MP
    {
        get
        {
            return 30;
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
        // Debug.Log("jieshu");
        state.OnEndSkill();
    }

    public int OnMiddleSkillAnimation()
    {
        throw new NotImplementedException();
    }

    public void OnMiddleSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        Player player = PlayerMediator.OnGetPlayerMediator().player;
        GameObject temp = player.FlyItem[2];
        GameObject.Instantiate(temp, player.FlyItemPosition.position, temp.transform.rotation);
    }

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillRangeRemoteAttack);
        state.OnUseSkill(true);
    }
}
