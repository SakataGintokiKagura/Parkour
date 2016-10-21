﻿using System;
using UnityEngine;


class Invincible : AbsState
{
    public Invincible(PlayerState player) : base(player)
    {
    }
    /// <summary>
    /// 停止无敌状态
    /// </summary>
    /// <returns></returns>
    public override AbsState OnGrounded()
    {
        return player.unInvincible;
    }
    /// <summary>
    /// 开始无敌状态
    /// </summary>
    /// <returns></returns>
    public override AbsState OnJump()
    {
        return this;
    }

    public override AbsState OnUseSkill(bool isInterrupted)
    {
        Debug.Log("状态出错");
        return this;
    }
}