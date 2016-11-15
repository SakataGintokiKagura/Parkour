using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Reflection;
using UnityEngine.Assertions.Must;
public class UI : MonoBehaviour
{
    private int hPInitizal = 0;
	private int mPInitizal = 0;
	public Image HP;
	public Image MP;
	public Text injured;
	public Text allCoin;
    private PlayerMediator playerMediator;
    private bool jump = false;
    private bool startJump = false;
    private bool skillA = false;
    private bool skillB = false;
    private bool startReadTime = false;
    private float usedtime = 0;
    private float curTime = 0;
    private ReadTable skillTable;
    //private ArrayList

    private float time;
    private string skillName = null;
    private int stringLen = 0;
    private bool isButtonAHaveDown = false;
    private bool isButtonBHaveDown = false;
    private bool temp = false;
    private bool isA = false;
    private float waitDownTime;
    private float waitTime;
	void Start()
	{
		playerMediator = PlayerMediator.OnGetPlayerMediator ();
		playerMediator.OnSetUI (this);
		hPInitizal = 100;
		mPInitizal = 100;
		waitDownTime = float.Parse(ReadTable.getTable.OnFind("skillParameber", "10", "dateValue"));
		waitTime = float.Parse(ReadTable.getTable.OnFind("skillParameber", "11", "dateValue"));
	}
    // Update is called once per frame

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMediator.OnJump();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnButtonADown();
        }
        else
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnButtonBDown();
        }
        else
        if (Input.GetKeyUp(KeyCode.A))
        {
            OnButtonAUp();
        }
        else
        if (Input.GetKeyUp(KeyCode.D))
        {
            OnButtonBUp();
        }

        if (isButtonAHaveDown || isButtonBHaveDown)
        {
            time += Time.deltaTime;
        }
        if (time > waitTime && temp)
        {
            isA = true;
            skillName = "AAA";
            SkillCheck(skillName);

        }

    }

    public void OnButtonADown()
    {
        isButtonAHaveDown = true;
        temp = true;
        if (isButtonBHaveDown)
        {
            if (time < waitDownTime)
            {
                skillName = "BA";
                SkillCheck(skillName);
                OnInit();
            }
        }

    }
    /// <summary>
    /// A键抬起
    /// </summary>
    public void OnButtonAUp()
    {
        if (isA)
        {
            isA = false;

            OnInit();
        }
        temp = false;

        if (time < waitTime)
        {
            time = 0;
        }
        StartCoroutine(Wait());

    }
    /// <summary>
    /// B键按下
    /// </summary>
    public void OnButtonBDown()
    {
        isButtonBHaveDown = true;
        //第一次按下的是B键
        if (!isButtonAHaveDown)
        {

        }
        //第一次按下的是A键
        if (isButtonAHaveDown)
        {
            if (time < waitDownTime)
            {
                skillName = "AB";
                SkillCheck(skillName);

                OnInit();
            }
        }
    }
    /// <summary>
    /// B键抬起
    /// </summary>
    public void OnButtonBUp()
    {
        if (time > waitTime)
        {
            skillName = "BBB";
            SkillCheck(skillName);
            OnInit();

        }
        else
        {
            time = 0;
        }
        StartCoroutine(Wait());
    }
    /// <summary>
    /// 技能按完初始化
    /// </summary>
    void OnInit()
    {
        time = 0;
        //skillName = null;
        isButtonAHaveDown = false;
        isButtonBHaveDown = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitDownTime);
        if ((isButtonAHaveDown && isButtonBHaveDown) == false)
        {
            if (isButtonAHaveDown)
            {
                skillName = "A";
                SkillCheck(skillName);
                OnInit();
            }
            if (isButtonBHaveDown)
            {
                skillName = "B";
                SkillCheck(skillName);
                OnInit();
            }
        }
    }



    public int HPInitizal
    {
        get
        {
            return hPInitizal;
        }

        set
        {
            if (hPInitizal == 0)
                hPInitizal = value;
        }
    }

    public int MPInitizal
    {
        get
        {
            return mPInitizal;
        }

        set
        {
            if (mPInitizal == 0)
                mPInitizal = value;
        }
    }
    public void SkillCheck(string skillName)
    {
        string str = "1111";
        for (int i = 1; i < 7; i++)

        {
            string s = i.ToString();
            str = ReadTable.getTable.OnFind("skillDate", s, "skillKeys");
            if (str == skillName)
            {
                Debug.Log("技能释放");
                Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集 
                String s1 = ReadTable.getTable.OnFind("skillDate", s, "skillName");
                object obj = assembly.CreateInstance(s1); // 创建类的实例，返回为 object 类型，需要强制类型转换
                Debug.Log("技能释放开始   " + str);
                playerMediator.OnUseSkill((ISkill)obj);
                break;
            }
        }
    }

    public void OnButtonJump()
    {
        playerMediator.OnJump();

    }
}

