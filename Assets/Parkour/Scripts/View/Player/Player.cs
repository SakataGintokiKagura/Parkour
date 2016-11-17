using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using CammerState;
using DG.Tweening;
using NPlayerState;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour {
	public GameObject[] effect;
	private int id =0;
	public Transform FlyItemPosition;
	private ISkill treadAttack = new SkillTreadAttack();
	private PlayerMediator playerMediator;
	private ISkill skill;
	private Animator anim;
	private bool isfly;
	private bool isDrop;
	private CharacterController controller;
	private Vector3 velocity;
	private PlayerState state;
    private GameStates gameStates;
	private float initialVelocity;
	[SerializeField]
	private SphereCollider lHard;
	[SerializeField]
	private SphereCollider rHard;
	public bool isApplyGravity = true;
    public CameraFollow CF;
    ReadTable table = ReadTable.getTable;
    public Vector3 Velocity
	{
		get
		{
			return velocity;
		}

		set
		{
			velocity = value;
		}
	}
	public ISkill Skill
	{
		get
		{
			return skill;
		}
	}

	public PlayerState State
	{
		get
		{
			return state;
		}

		private set
		{
			state = value;
		}
	}

    public GameStates GameStaes
    {
        get
        {
            return gameStates;
        }

        private set
        {
            gameStates = value;
        }
    }
	public bool Isfly
	{
		get
		{
			return isfly;
		}
	}
		
	/// <summary>
	/// 初始化移动参数
	/// </summary>
	void Start()
	{
		playerMediator = PlayerMediator.OnGetPlayerMediator ();
        playerMediator.player = this;
		//playerMediator.OnSetPlayer (this);
		State = PlayerState.Instance;
	    gameStates = GameStates.getInstance;
		anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
		initialVelocity = MotionParameber.initialVelocity * MotionParameber.fixedMotion;
		velocity = new Vector3(initialVelocity, 0, 0);
		//StartCoroutine(OnAccelerate());
		anim.SetFloat(AnimationParameter.xSpeed, velocity.x);
		anim.SetFloat(AnimationParameter.ySpeed, velocity.y);
		anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpGround);
		//        StartCoroutine(OnFly(10f));
        
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
		if (isDrop)
		{
			velocity.y = 0;
			isDrop = false;
		}
		else
			velocity.y = (transform.position.y - lastPosition.y);
		if ((flags & CollisionFlags.Below) == 0 && (State.singletonState is Run))
		{
			anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpfirst);
		}
		anim.SetFloat(AnimationParameter.xSpeed, velocity.x);
		anim.SetFloat(AnimationParameter.ySpeed, velocity.y);

		if (Camera.main.WorldToViewportPoint(transform.position).x < 0)
		{
			playerMediator.OnDropOutPit();
		}
		if (isfly)
			isApplyGravity = false;
    }
	/// <summary>
	/// 施加重力
	/// </summary>
	/// <param name="velocity"></param>
	/// <returns></returns>
	Vector3 ApplyGravity(Vector3 velocity)
	{
		if (!isApplyGravity)
			return velocity;
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
		if (State.singletonState is Run)
		{
			velocity.y = 0;
			velocity += MotionParameber.jumpDir * MotionParameber.fixedMotion;
			State.OnJump();
			anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpfirst);
		}
		else if (State.singletonState is FirstJump)
		{
			velocity.y = 0;
			velocity += MotionParameber.jumpDir * MotionParameber.secondJump * MotionParameber.fixedMotion;
			State.OnJump();
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
			if (velocity.x > MotionParameber.speedMax)
				break;
		}

	}
	/// <summary>
	/// 开始使用技能
	/// </summary>
	/// <param name="skill"></param>
	public void OnStartSkill(ISkill skill)
	{
		if (State.sharedStates[0] is GeneralSkill || State.sharedStates[0] is UnInterruptedSkill)
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
				skill.OnStartSkillAnimation(transform, anim, State);
			}
		}
		else
		{
			this.skill = skill;
			skill.OnStartSkillAnimation(transform, anim, State);
			if(skill is IMeleeAttack)
			{
				lHard.enabled = true;
				rHard.enabled = true;
			}
			if (skill is SkillCallRemoteAttack)
				OnEndSkill();
		}
	}
	/// <summary>
	/// 使用技能中
	/// </summary>
	public void OnMiddleSkill()
	{
		skill.OnMiddleSkillAnimation(FlyItemPosition, anim, State);
	}
	/// <summary>
	/// 使用技能结束
	/// </summary>
	public void OnEndSkill()
	{

		skill.OnEndSkillAnimation(transform, anim, State);
		if (skill is IMeleeAttack)
		{
			lHard.enabled = false;
			rHard.enabled = false; ;
		}
		skill = null;
		effect[id].SetActive(false);
	}
	/// <summary>
	/// 有物体与角色碰撞
	/// </summary>
	/// <param name="hit"></param>
	void OnControllerColliderHit(ControllerColliderHit hit)
	{

		if (hit.normal.y > 0.5f)
		{
			State.OnGrounded();
			anim.SetInteger(AnimationParameter.jump, AnimationParameter.jumpGround);
		}

		if (hit.collider.tag == TagParameber.bottom)
			playerMediator.OnDropOutPit();
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

		}else if(col.transform.root.gameObject.tag == TagParameber.monster)
			OnHurtCheck(col.gameObject);
		else if(col.tag == TagParameber.prop)
			playerMediator.OnPickUpProp(col.gameObject);
		else if(col.tag == TagParameber.red)
		{
		    OnFlyNearPos();
            CF.OnNearCamera();
		}
        else if (col.tag == TagParameber.yellow)
		{
		    OnFlyFarPos();
            CF.OnFarCamera();
		}
		else if(col.tag==TagParameber.blue)
		{
			if (gameStates.singleGameState is FarCammerState)

		    {
                OnFlyNearPos();
                CF.OnMidCamera();
            }    
		    else
		    {

		        OnFlyFarPos();
                CF.OnMidCamera();
		    }
		}else if (col.gameObject.name.Contains("Move"))
		{
		    string[] temp = col.gameObject.name.Split('/');
		    float targetPos = float.Parse(table.OnFind("terrainMoveDate", temp[1], "Target"));
		    string type = table.OnFind("terrainMoveDate", temp[1], "Type");

            if (type.Equals("Up"))
		    {
		        col.transform.DOLocalMoveY(targetPos,1.5f,false).SetLoops(-1,LoopType.Yoyo);
		    }
		    else
		    {
		        col.transform.DOLocalMoveX(targetPos, 1f, false).SetLoops(1).SetRelative(true);
		    }

		}
        //else if (col.gameObject.name.Contains("Move"))
        //{
        //    string[] temp = col.gameObject.name.Split('/');
        //    string move = ReadTable.getTable.OnFind("11", temp[1], "111");
        //}

    }
	/// <summary>
	/// 伤害检测
	/// </summary>
	/// <param name="monster"></param>
	void OnHurtCheck(GameObject monster)
	{
		Ray rayB = new Ray(transform.position + new Vector3(-0.2f, 0.5f, 0), Vector3.down);
		RaycastHit hitB;
		Physics.Raycast(rayB, out hitB);
		if (Physics.Raycast(rayB, out hitB))
		{
			if (hitB.collider.tag == TagParameber.monster)
			{
				MonsterMediator.OnGetMonsterMediator().OnInjured(monster.transform.root.gameObject, treadAttack);
				velocity.y = 0;
				velocity.y += MotionParameber.elasticTread;

				return;
			}
		}
		OnHurt(monster);
	}
	/// <summary>
	/// 人物掉落执行
	/// </summary>
	public void OnDropOut()
	{
		//Debug.Log(velocity);
		Vector3 position = transform.position;
		position += MotionParameber.rebornDelta;
		position.y = 3;
		transform.position = position;
		isDrop = true;
		if (state.singletonState is Run)
		{
			state.OnJump();
		}
		//velocity.y = 0;
	}
	/// <summary>
	/// 辅助技能无敌
	/// </summary>
	/// <param name="time"></param>
	/// <returns></returns>
	IEnumerator OnInvincibleTime(float time)
	{
		while (State.sharedStates[1] is Invincible)
		{
			yield return new WaitForFixedUpdate();
			time -= MotionParameber.fixedMotion;
			if (time <= 0)
				break;
		}
		State.OnUnHurt();
		effect[4].SetActive(true);
		yield return new WaitForSeconds(time);
		//effect[4].SetActive(false);
		State.OnHurt();
		effect[4].SetActive(false);
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
		if (State.sharedStates[1] is UnInvincile)
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
		MonsterMediator.OnGetMonsterMediator ().monsterDic.Clear();
		Application.LoadLevel(2);
	}
	public void OnPlayEffect(int id)
	{
		effect[this.id].SetActive(false);
		this.id = id;
		effect[id].SetActive(true);
	}

	public void OnFly(float time)
	{
		StartCoroutine(OnFlyEffect(time));
	}
	public IEnumerator OnFlyEffect(float time)
	{
		isfly = true;
		velocity.y = 0;
		anim.SetTrigger(AnimationParameter.fly);
		isApplyGravity = false;
		effect[5].SetActive(true);
		StartCoroutine(OnInvincibleTime(time));
		while (transform.position.y < 3f)
		{
			transform.Translate(0, 2f*MotionParameber.fixedMotion, 0);
			velocity.y = 0;
			yield return new WaitForFixedUpdate();
			time -= MotionParameber.fixedMotion;
		}
		yield return new WaitForSeconds(time);
		effect[5].SetActive(false);
		isApplyGravity = true;
		velocity.y = 0;
		isfly = false;
	}


    void OnFlyFarPos()
    {
        transform.position = new Vector3(transform.position.x, 0.005f, transform.position.z);
        anim.SetTrigger("Turn");
        CF.OnFlyFarPos();
        transform.DOPath(MotionParameber.FarTargetPos, 1, PathType.CatmullRom).SetLoops(1).SetRelative(true);
        gameStates.OnSwitfRunWay(false);
    }

    void OnFlyNearPos()
    {
        transform.position = new Vector3(transform.position.x, 0.005f, transform.position.z);
        anim.SetTrigger("Turn");
        CF.OnFlyNearPos();
        transform.DOPath(MotionParameber.nearTargetPos, 1, PathType.CatmullRom).SetLoops(1).SetRelative(true);
        gameStates.OnSwitfRunWay(true);
    }
}