using UnityEngine;
using System.Collections;
using System;
using NPlayerState;

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
        ReadTable table = ReadTable.getTable;

		MemoryController.instance.OnFindGameObjectByName (
			table.OnFind ("flyItemDate", "2", "name"),
			transform.position,
			table.OnFind ("memoryObjectParameter", "5", "priority"),
			table.OnFind ("memoryObjectParameter", "5", "path")
		);
	}
//        GameObject temp = Resources.Load("FlyItem/" + table.OnFind("flyItemDate", "2", "name")) as GameObject;
//        GameObject.Instantiate(temp, transform.position, temp.transform.rotation);
	

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillBigRemoteAttack);
        state.OnUseSkill(true);
        Player player = PlayerMediator.OnGetPlayerMediator().player;
        if (!(player.State.singletonState is Run))
        {
            if (player.Velocity.y < 0)
                player.Velocity += Vector3.up * 0.3f;
        }
    }
}
