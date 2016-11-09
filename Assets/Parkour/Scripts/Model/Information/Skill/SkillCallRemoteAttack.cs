using UnityEngine;
using System.Collections;
using System;
using NPlayerState;

public class SkillCallRemoteAttack : ISkill {
    public float damage
    {
        get
        {
            return 1000;
        }
    }

    public int MP
    {
        get
        {
            return 40;
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
        state.OnEndSkill();
    }

    public int OnMiddleSkillAnimation()
    {
        throw new NotImplementedException();
    }

    public void OnMiddleSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        throw new NotImplementedException();
    }

    public bool OnSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        throw new NotImplementedException();
    }

    public bool OnSkillAnimation(ref Vector3 velocity, Animator anim, PlayerState state)
    {
        throw new NotImplementedException();
    }

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        state.OnUseSkill(true);
        GameObject pet = Resources.Load("Pet/" + "dragon")as GameObject;
        GameObject.Instantiate(pet, Vector3.zero, pet.transform.rotation);
    }
}
