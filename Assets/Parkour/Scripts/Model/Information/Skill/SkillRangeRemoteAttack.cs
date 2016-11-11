﻿using UnityEngine;
using System.Collections;
using System;
using NPlayerState;

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

		MemoryController.instance.OnFindGameObjectByName (
			table.OnFind ("flyItemDate", "3", "name"),
			transform.position,
			MemoryParameter.FlyItemPriority.ToString(),
			table.OnFind ("flyItemDate", "3", "path"),
			table.OnFind ("flyItemDate", "3", "load"),
			"3",
			new ReturnObject(MemoryController.instance.emptyDelegate)
		);

//        GameObject temp = Resources.Load("FlyItem/" + table.OnFind("flyItemDate", "3", "name")) as GameObject;
//        GameObject.Instantiate(temp, transform.position, temp.transform.rotation);
    }

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        anim.SetInteger(AnimationParameter.skill, AnimationParameter.skillRangeRemoteAttack);
        state.OnUseSkill(true);
        Player player = PlayerMediator.OnGetPlayerMediator().player;
        Vector3 temp = player.Velocity;
        temp.y = 0;
        player.Velocity = temp;
        player.isApplyGravity = false;
    }
}
