using UnityEngine;
using System.Collections;
using System;

public class SkillNormalAttack : IEnbaleAirSkill, IMeleeAttack
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
        //Debug.Log(11111);
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
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillNormalAttack);
        state.OnUseSkill(true);
    }

    //public bool OnSkillAnimation(ref Vector3 velocity, Animator anim, PlayerState state)
    //{
    //    throw new NotImplementedException();
    //}

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
