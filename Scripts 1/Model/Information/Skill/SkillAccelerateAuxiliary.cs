using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// 唐耀 技能规划，技能控制设计
/// 加速
/// </summary>
public class SkillAccelerateAuxiliary : IAuxiliary {
    public float damage
    {
        get
        {
            return 0;
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
        throw new NotImplementedException();
    }

    public int OnMiddleSkillAnimation()
    {
        throw new NotImplementedException();
    }

    public void OnMiddleSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        throw new NotImplementedException();
    }

    public void OnStartSkillAnimation(Transform transform, Animator anim, PlayerState state)
    {
        throw new NotImplementedException();
    }

}
