using UnityEngine;
using System.Collections;
using System;
using NPlayerState;
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

		MemoryController.instance.OnFindGameObjectByName (
			table.OnFind("flyItemDate", "1", "name"),
			transform.position,
			table.OnFind ("memoryObjectParameter", "5", "priority"),
			table.OnFind ("memoryObjectParameter", "5", "path")
		);

//        GameObject temp = Resources.Load("FlyItem/" + table.OnFind("flyItemDate", "1", "name"))as GameObject;
//        GameObject.Instantiate(temp,transform.position,temp.transform.rotation);
    }

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillNormalRemoteAttack);
        state.OnUseSkill(true);
        Player player = PlayerMediator.OnGetPlayerMediator().player;
        if (!(player.State.singletonState is Run))
        {
            if (player.Velocity.y < -0.1f)
                player.Velocity += Vector3.up * 0.3f;
        }
    }
}
