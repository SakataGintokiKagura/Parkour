using UnityEngine;
using System.Collections;
using System;

public class SkillFlashAuxiliary : IAuxiliary {
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
            return 20;
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
        transform.Translate(new Vector3(0, 0, SkillParameber.flashDelta));
    }

}
