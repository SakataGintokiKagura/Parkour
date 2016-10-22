using UnityEngine;
using System.Collections;
/// <summary>
/// 唐耀 技能规划，技能控制设计
/// 总技能接口
/// </summary>

public interface ISkill {
	float damage { get; }
    int MP { get; }
    float time { get; }
    void OnStartSkillAnimation(Transform transform, Animator anim,PlayerState state);
    void OnMiddleSkillAnimation(Transform transform, Animator anim, PlayerState state);
    int OnMiddleSkillAnimation();
    void OnEndSkillAnimation(Transform transform, Animator anim, PlayerState state);
}
