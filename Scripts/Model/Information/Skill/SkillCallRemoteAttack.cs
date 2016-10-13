using UnityEngine;
using System.Collections;
using System;

public class SkillCallRemoteAttack : ISkill {
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

    public bool OnSkillAnimation(ref Vector3 velocity, Animator anim, PlayerState state)
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
