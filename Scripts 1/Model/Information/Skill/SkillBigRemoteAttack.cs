using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// 唐耀 技能规划，技能控制设计
/// 加强远程攻击
/// </summary>
public class SkillBigRemoteAttack : IEnbaleAirSkill  {
    public float damage
    {
        get
        {
            return 1;
        }
    }

    public int MP
    {
        get
        {
            return 15;
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
        GameObject temp = player.FlyItem[1];
        GameObject.Instantiate(temp, player.FlyItemPosition.position, temp.transform.rotation);
    }

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillBigRemoteAttack);
        state.OnUseSkill(true);
    }
}
