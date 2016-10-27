using UnityEngine;
using System.Collections;
using System;

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
        ReadTable table = ReadTable.getTable;
        GameObject temp = Resources.Load("FlyItem/" + table.OnFind("flyItemDate", "3", "name")) as GameObject;
        GameObject.Instantiate(temp, transform.position, temp.transform.rotation);
    }

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillRangeRemoteAttack);
        state.OnUseSkill(true);
    }
}
