using UnityEngine;
using System.Collections;
using System;
using NPlayerState;

public class SkillLightRemoteAttack : ISkill
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
        ReadTable table = ReadTable.getTable;
        GameObject temp = Resources.Load("FlyItem/" + table.OnFind("flyItemDate", "4", "name")) as GameObject;
        GameObject.Instantiate(temp, transform.position, temp.transform.rotation);
    }

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillLightRemoteAttack);
        state.OnUseSkill(true);
    }
}
