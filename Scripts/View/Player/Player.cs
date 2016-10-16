using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {
    private IPlayerMediator playerMediator;
    private ISkill skill;
    private Animator anim;
    private CharacterController controller;
    private Vector3 velocity;
    private PlayerState state;
    private float initialVelocity;
    void Awake()
    {
    }
    void Start()
    {
        state = PlayerState.Instance;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        initialVelocity = MotionParameber.initialVelocity *MotionParameber.fixedMotion;
        velocity = new Vector3(initialVelocity, 0, 0);
        //StartCoroutine(OnAccelerate());
        anim.SetFloat(AnimationParameter.xSpeed, velocity.x);
        anim.SetFloat(AnimationParameter.ySpeed, velocity.y);
        anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpGround);
    }
    void FixedUpdate()
    {
        velocity = ApplyGravity(velocity);
        Vector3 lastPosition = transform.position;
        CollisionFlags flags = controller.Move(velocity);
        velocity = (transform.position - lastPosition);
        velocity = OnCheckVelocity(velocity);
        if ((flags & CollisionFlags.Below) == 0 && (state.jumpState is Run))
        {
            state.OnJump(true);
            anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpfirst);
        }
        anim.SetFloat(AnimationParameter.xSpeed, velocity.x);
        anim.SetFloat(AnimationParameter.ySpeed, velocity.y); 
    }
    Vector3 ApplyGravity(Vector3 velocity)
    {
        velocity.y -= MotionParameber.gravity * MotionParameber.fixedMotion;
        return velocity;
    }
    Vector3 OnCheckVelocity(Vector3 velovity)
    {
        if (velocity.y > MotionParameber.jumpDir.y * MotionParameber.fixedMotion)
        {
            velocity.y = MotionParameber.jumpDir.y * MotionParameber.fixedMotion;
        }
        return velocity;
    }
    public void OnJump()
    {
        if (state.jumpState is Run)
        {
            velocity.y = 0;
            velocity += MotionParameber.jumpDir * MotionParameber.fixedMotion;
            state.OnJump(true);
            anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpfirst);
        }
        else if (state.jumpState is FirstJump)
        {
            velocity.y = 0;
            velocity += MotionParameber.jumpDir*MotionParameber.secondJump * MotionParameber.fixedMotion;
            state.OnJump(true);
            anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpsecond);
        }
        
    }
    IEnumerator OnAccelerate()
    {
        while (true)
        {
            yield return new WaitForSeconds(MotionParameber.accelerationCD);
            velocity.x += MotionParameber.acceleration * MotionParameber.fixedMotion;
        }

    }
    public void OnSetSkill(ISkill skill)
    {
        if (this.skill == null)
        {
            this.skill = skill;
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((controller.collisionFlags & CollisionFlags.Below) != 0 && !(state.jumpState is Run))
        {
            //Debug.Log(controller.collisionFlags);
            state.OnGrounded();
            anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpGround);
        }
    }
    public void OnSetPlayerMediator(IPlayerMediator playerMediator)
    {
        this.playerMediator = playerMediator;
    }
}
