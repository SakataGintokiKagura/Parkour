using UnityEngine;
using System.Collections;
using System;
using NPlayerState;

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
        PlayerMediator.OnGetPlayerMediator().player.isApplyGravity = true;
    }

    public int OnMiddleSkillAnimation()
    {
        throw new NotImplementedException();
    }

    public void OnMiddleSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        ReadTable table = ReadTable.getTable;

		MemoryController.instance.OnFindGameObjectByName (
			table.OnFind("flyItemDate", "4", "name"),
			transform.position,
			table.OnFind ("memoryObjectParameter", "5", "priority"),
			table.OnFind ("memoryObjectParameter", "5", "path")
		);

//        GameObject temp = Resources.Load("FlyItem/" + table.OnFind("flyItemDate", "4", "name")) as GameObject;
//        GameObject.Instantiate(temp, transform.position, temp.transform.rotation);
    }

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillLightRemoteAttack);
        state.OnUseSkill(true);
        Player player = PlayerMediator.OnGetPlayerMediator().player;
        if (!(player.State.singletonState is Run))
        {
            if (player.Velocity.y < 0.1f)
            {
                Vector3 temp = player.Velocity;
                temp.y = 0;
                player.Velocity = temp;
                player.isApplyGravity = false;
            }
        }
    }
}
