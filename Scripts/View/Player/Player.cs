﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour {
    //public GameObject[] FlyItem;
    public Transform FlyItemPosition;
    private ISkill treadAttack = new SkillTreadAttack();
    [SerializeField]
    private Light invincibleEffects;
    /// <summary>
    /// 赤橙黄绿青蓝紫 对应的三原色
    /// </summary>
    private Color[] invincibleColor = { new Color(255, 0, 0), new Color(255, 128, 0), new Color(255, 255, 0), new Color(0, 255, 0), new Color(0, 255, 255), new Color(0, 0, 255), new Color(128, 0, 255), new Color(255, 255, 255) };
    private IPlayerMediator playerMediator;
    private ISkill skill;
    private Animator anim;
    private CharacterController controller;
    private Vector3 velocity;
    private PlayerState state;
    private float initialVelocity;
    [SerializeField]
    private SphereCollider lHard;
    [SerializeField]
    private SphereCollider rHard;

    public Vector3 Velocity
    {
        get
        {
            return velocity;
        }
    }
    public ISkill Skill
    {
        get
        {
            return skill;
        }
    }
    void Awake()
    {
    }
    /// <summary>
    /// 初始化移动参数
    /// </summary>
    void Start()
    {
        state = PlayerState.Instance;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        initialVelocity = MotionParameber.initialVelocity * MotionParameber.fixedMotion;
        velocity = new Vector3(initialVelocity, 0, 0);
        //StartCoroutine(OnAccelerate());
        anim.SetFloat(AnimationParameter.xSpeed, velocity.x);
        anim.SetFloat(AnimationParameter.ySpeed, velocity.y);
        anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpGround);
    }
    /// <summary>
    /// 每帧移动物体，并对物体施加重力
    /// 更改动画参数
    /// 更改角色状态
    /// </summary>
    void FixedUpdate()
    {
        velocity = ApplyGravity(velocity);
        Vector3 lastPosition = transform.position;
        CollisionFlags flags = controller.Move(velocity);
        //velocity = (transform.position - lastPosition);
        if ((flags & CollisionFlags.Below) == 0 && (state.jumpState is Run))
        {
            state.OnJump();
            anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpfirst);
        }
        anim.SetFloat(AnimationParameter.xSpeed, velocity.x);
        anim.SetFloat(AnimationParameter.ySpeed, velocity.y);
        if (state.hurtState is Invincible)
        {
            invincibleEffects.enabled = true;
            invincibleEffects.color = invincibleColor[Random.Range(0, 7)];
        }
        else
        {
            invincibleEffects.enabled = false;
            invincibleEffects.color = invincibleColor[7];
        }
        if (transform.position.y < MotionParameber.yLimit)
        {
            playerMediator.OnDropOutPit();
        }
    }
    /// <summary>
    /// 施加重力
    /// </summary>
    /// <param name="velocity"></param>
    /// <returns></returns>
    Vector3 ApplyGravity(Vector3 velocity)
    {
        velocity.y -= MotionParameber.gravity * MotionParameber.fixedMotion;
        return velocity;
    }
    /// <summary>
    /// 控制角色跳跃
    /// </summary>
    public void OnJump()
    {
        if (skill != null)
            return;
        if (state.jumpState is Run)
        {
            velocity.y = 0;
            velocity += MotionParameber.jumpDir * MotionParameber.fixedMotion;
            state.OnJump();
            anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpfirst);
        }
        else if (state.jumpState is FirstJump)
        {
            velocity.y = 0;
            velocity += MotionParameber.jumpDir * MotionParameber.secondJump * MotionParameber.fixedMotion;
            state.OnJump();
            anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpsecond);
        }

    }
    /// <summary>
    /// 对角色进行加速
    /// </summary>
    /// <returns></returns>
    IEnumerator OnAccelerate()
    {
        while (true)
        {
            yield return new WaitForSeconds(MotionParameber.accelerationCD);
            velocity.x += MotionParameber.acceleration * MotionParameber.fixedMotion;
        }

    }
    /// <summary>
    /// 开始使用技能
    /// </summary>
    /// <param name="skill"></param>
    public void OnStartSkill(ISkill skill)
    {
        if (state.skillState is GeneralSkill || state.skillState is UnInterruptedSkill)
            return;
        if (this.skill != null)
        {
            Debug.Log("技能使用出错");
            return;
        }
        if (skill is IAuxiliary)
        {
            if (skill is SkillInvicibleAuxiliary)
            {
                StartCoroutine(OnInvincibleTime(SkillParameber.skillInvilicibleAuxiliaryTime));
            }
            else if (skill is SkillAccelerateAuxiliary)
            {
                StartCoroutine(OnAccelerate(SkillParameber.skillAccelerateAuxiliaryTime));
            }
            else if (skill is SkillFlashAuxiliary)
            {
                skill.OnStartSkillAnimation(transform, anim, state);
            }
        }
        else
        {
            this.skill = skill;
            skill.OnStartSkillAnimation(transform, anim, state);
            if(skill is IMeleeAttack)
            {
                lHard.enabled = true;
                rHard.enabled = true;
            }
        }
    }
    /// <summary>
    /// 使用技能中
    /// </summary>
    public void OnMiddleSkill()
    {
        skill.OnMiddleSkillAnimation(FlyItemPosition, anim, state);
    }
    /// <summary>
    /// 使用技能结束
    /// </summary>
    public void OnEndSkill()
    {

        skill.OnEndSkillAnimation(transform, anim, state);
        if (skill is IMeleeAttack)
        {
            lHard.enabled = false;
            rHard.enabled = false; ;
        }
        skill = null;
    }
    /// <summary>
    /// 有物体与角色碰撞
    /// </summary>
    /// <param name="hit"></param>
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((controller.collisionFlags & CollisionFlags.Below) != 0 && !(state.jumpState is Run))
        {
            state.OnGrounded();
            anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpGround);
        }
    }
    public void OnSetPlayerMediator(IPlayerMediator playerMediator)
    {
        this.playerMediator = playerMediator;
    }
    /// <summary>
    /// 有特殊的物体与主角碰撞
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == TagParameber.coin)
        {
            playerMediator.OnGetScoure(1);
			col.gameObject.SetActive (false);
        }else if(col.tag == TagParameber.monster)

        {
            //Debug.Log(1111);
            OnHurtCheck(col.gameObject);
        }else if(col.tag == TagParameber.prop)
        {
            playerMediator.OnPickUpProp(col.gameObject);
           

        }

    }
    /// <summary>
    /// 伤害检测
    /// </summary>
    /// <param name="monster"></param>
    void OnHurtCheck(GameObject monster)
    {
        Ray rayB = new Ray(transform.position + new Vector3(-0.2f, 1.3f, 0), Vector3.down);
        RaycastHit hitB;
        Physics.Raycast(rayB, out hitB);
        if (Physics.Raycast(rayB, out hitB))
        {
            //Debug.Log(hita.collider.tag);
            if (hitB.collider.tag == TagParameber.monster)
            {
                MonsterMediator.OnGetMonsterMediator().OnInjured(monster.transform.root.gameObject, treadAttack);
                velocity.y = 0;
                velocity.y += MotionParameber.elasticTread;
                //OnHurt(monster);
                return;
            }
        }
        OnHurt(monster);
        //OnHurt(monster);
    }
    /// <summary>
    /// 人物掉落执行
    /// </summary>
    public void OnDropOut()
    {
        //Debug.Log(velocity);
        Vector3 position = transform.position;
        position += MotionParameber.rebornDelta;
        position.y = 0;
        transform.position = position;
        velocity.y = 0;
    }
    /// <summary>
    /// 辅助技能无敌
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator OnInvincibleTime(float time)
    {
        while (state.hurtState is Invincible)
        {
            yield return new WaitForFixedUpdate();
            time -= MotionParameber.fixedMotion;
            if (time <= 0)
                break;
        }
        state.OnUnHurt();
        yield return new WaitForSeconds(time);
        state.OnHurt();
    }
    /// <summary>
    /// 辅助技能：加速
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator OnAccelerate(float time)
    {
        velocity += SkillParameber.skillAccelerateAuxiliaryDelta;
        yield return new WaitForSeconds(time);
        velocity -= SkillParameber.skillAccelerateAuxiliaryDelta;
    }
    /// <summary>
    /// 受伤
    /// </summary>
    /// <param name="monster"></param>
    void OnHurt(GameObject monster)
    {
        if (state.hurtState is UnInvincile)
        {
            playerMediator.OnInjured(monster.transform.root.gameObject);
            StartCoroutine(OnInvincibleTime(SkillParameber.hurtInvilicibleTime));
        }
    }

    public void OnDie()
    {
        anim.SetTrigger(AnimationParameter.dead);
        velocity = new Vector3(0, 0, 0);
    }
    public void OnReStart()
    {
        Debug.Log("restart");
    }
    /// <summary>
    /// 拾取道具
    /// </summary>
    
}