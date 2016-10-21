using UnityEngine;
using System.Collections;

public class SkillParameber : MonoBehaviour {

    public const float flashDelta = 2f;
    public const float hurtInvilicibleTime = 0.5f;
    public const float skillInvilicibleAuxiliaryTime = 2.0f;
    public const float skillAccelerateAuxiliaryTime = 3.0f;
    public static Vector3 skillAccelerateAuxiliaryDelta = new Vector3(3 * MotionParameber.fixedMotion, 0, 0);

    public const int dropOutHurt = 50;
    public const float SkillReadCD=0.3f;
    public const int reply = 10;
}
