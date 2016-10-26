using UnityEngine;
using System.Collections;

public class AnimationParameter{
	public const string xSpeed = "XSpeed";
    public const string ySpeed = "YSpeed";
	public const string jump = "Jump";
    public const string skill = "Skill";
    public const string dead = "Dead";
    public const int jumpGround = 0;
    public const int jumpfirst = 1;
    public const int jumpsecond = 2;

    public const int skillUnUse = -1;
    public const int skillNormalAttack = 1;
    public const int skillRollAttack = 2;
    public const int skillBigRollAttack = 3;
    public const int skillRangeAttack = 4;
    public const int skillIaidoAttack = 5;

    public const int skillNormalRemoteAttack = 6;
    public const int skillBigRemoteAttack = 7;
    public const int skillRangeRemoteAttack = 8;
    public const int skillLightRemoteAttack = 9;
    public const int SkillCallRemoteAttack = 10;
}