using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

using UnityEngine.EventSystems;
using System.Reflection;

public class UI : MonoBehaviour
{
    public Image HP;
    public Image MP;
    public Text injured;
    public Text allCoin;
    private IPlayerMediator playerMediator;
    private bool jump = false;
    private bool startJump = false;
    private bool skillA = false;
    private bool skillB = false;
    private bool startReadTime = false;
    private float usedtime = 0;
    private float curTime = 0;
    private ArrayList listSkill;
    private ReadTable skillTable;
    void Start()
    {

        listSkill = new ArrayList();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            playerMediator.OnUseSkill(new SkillContinuousAttack());
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startJump = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            skillA = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            skillB = true;
        }

        //按钮识别
        if (startJump)
        {
            startJump = false;
            playerMediator.OnJump();
            curTime = 0;

        }
        //按键技能触发
        if (skillA)
        {
            startReadTime = true;
            skillA = false;
            listSkill.Add("A");

        }
        if (skillB)
        {
            startReadTime = true;
            skillB = false;
            listSkill.Add("B");
            curTime = 0;

        }
        if (startReadTime == true)
        {
            curTime = curTime + Time.deltaTime;
                if (curTime >= SkillParameber.SkillReadCD)
                {
                SkillCheck(listSkill);
                listSkill.Clear();
                startReadTime = false;
                curTime = 0;
            }
        }

    }
    public void OnSetPlayerMediator(IPlayerMediator playerMediator)
    {
        this.playerMediator = playerMediator;
    }
    public void SkillCheck(ArrayList listSkill)
    {
        string skilllist=null;
        foreach (string a in listSkill)
        {
            skilllist += a;
        }
        string str ="1111";
        for (int i=1;i<32;i++)
        {
            string s=i.ToString();
            str = ReadTable.getTable.OnFind("skillDate", s, "skillKeys");
            if (str == skilllist)
            {
                Debug.Log("技能释放");
                Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集 
                String s1 = ReadTable.getTable.OnFind("skillDate", s, "skillName");
                object obj = assembly.CreateInstance(s1); // 创建类的实例，返回为 object 类型，需要强制类型转换
                Debug.Log(obj);
                Debug.Log("技能释放开始   " + str);
                playerMediator.OnUseSkill((ISkill)obj);
                break;
            }
        }
        
    }
    
    public void OnButtonA()
    {
        skillA = true;
    }
    public void OnButtonB()
    {
        skillB = true;


    }
    public void OnButtonJump()
    {
        startJump = true;

    }
    public void TimeText()
    {
        StartCoroutine(ssss());
    }
    IEnumerator ssss()
    {
        yield return new WaitForSeconds(MonsterParameber.damageShowTime);
        injured.transform.position = new Vector3(-15, 1, 0);
    }

}

