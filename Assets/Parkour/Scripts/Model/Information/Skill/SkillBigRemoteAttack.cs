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
        state.OnEndSkill();
        Player player = PlayerMediator.OnGetPlayerMediator().player;
        if (!player.Isfly)
            PlayerMediator.OnGetPlayerMediator().player.isApplyGravity = true;
    }

    public int OnMiddleSkillAnimation()
    {
        throw new NotImplementedException();
    }

    public void OnMiddleSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        ReadTable table = ReadTable.getTable;

		GameObject kill= MemoryController.instance.OnFindGameObjectByName (
			table.OnFind ("flyItemDate", "2", "name"),
			//transform.position,
			MemoryParameter.FlyItemPriority,
			table.OnFind ("flyItemDate", "2", "path"),
			"2"
		);

		kill.transform.position = transform.position;
	}

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillBigRemoteAttack);
        state.OnUseSkill(true);
        Player player = PlayerMediator.OnGetPlayerMediator().player;
        Vector3 temp = player.Velocity;
        temp.y = 0;
        player.Velocity = temp;
        player.isApplyGravity = false;
    }
}
