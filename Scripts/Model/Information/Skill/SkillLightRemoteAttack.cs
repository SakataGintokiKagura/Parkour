using UnityEngine;
using System.Collections;
using System;

public class SkillLightAttack : ISkill
{
    public float damage
    {
        get
        {
            return 3;
        }
    }

    public int MP
    {
        get
        {
            return 55;
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
        GameObject temp = player.FlyItem[3];
        GameObject.Instantiate(temp, player.FlyItemPosition.position, temp.transform.rotation);
    }

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillLightRemoteAttack);
        state.OnUseSkill(true);
    }
}
