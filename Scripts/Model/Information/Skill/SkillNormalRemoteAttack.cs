using UnityEngine;
using System.Collections;
using System;

public class SkillNormalRemoteAttack : IEnbaleAirSkill
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
            return 5;
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
        //GameObject.Instantiate(Resources.Load<GameObject>("NormalRemonteAttack"));
        ReadTable table = ReadTable.getTable;
        GameObject temp = Resources.Load("FlyItem/" + table.OnFind("flyItemDate", "1", "name"))as GameObject;
        GameObject.Instantiate(temp,transform.position,temp.transform.rotation);
        //GameObject.Instantiate(temp, player.FlyItemPosition.position+ new Vector3(0,2,0), Quaternion.identity);
        //Debug.Log("释放飞行道具");
    }

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillNormalRemoteAttack);
        state.OnUseSkill(true);
    }
}
