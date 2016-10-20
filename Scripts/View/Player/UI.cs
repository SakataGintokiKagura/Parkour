using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UI : MonoBehaviour {
    private IPlayerMediator playerMediator;
    private bool jump=false;
    private bool startJump= false;
    private bool skillA = false;
    private bool skillB = false;
    private bool startReadTime = false;
    private float usedtime = 0;
    private float curTime=0;
    private int jumpCount = 0;
    private ArrayList listSkill;

    private Text coinstext;
    private int coinsnum;
    void Start () {
     listSkill = new ArrayList();

    }
	// Update is called once per frame
	void Update () {
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

        }
        if (startReadTime == true)
        {
            curTime = curTime + Time.deltaTime;
            if (curTime > SkillParameber.SkillReadCD)
            {
                SkillCheck(listSkill);
                listSkill.Clear();
                startReadTime = false;
                curTime = 0;
            }
        }

    }
    public void OnSetPlayerMediator(IPlayerMediator playerMediator) {
        this.playerMediator = playerMediator;
    }
    public void SkillCheck(ArrayList listSkill) {
        int i = listSkill.Count;
        switch (i)
        {
            case 1:
                {
                    if (listSkill[0].ToString() == "A")
                    {

                        playerMediator.OnUseSkill(new SkillNormalAttack());
                        Debug.Log(" A技能 ");
                    }
                    else
                    {
                        playerMediator.OnUseSkill(new SkillNormalRemoteAttack());
                        Debug.Log(" B技能 ");
                    }
                    break;
                }
            case 2:
                {
                    if (listSkill[0].ToString() == "A")
                    {
                        if (listSkill[1].ToString() == "B")
                        {//AA
                            playerMediator.OnUseSkill(new SkillBigRemoteAttack());
                            Debug.Log(" AB  ");
                        }
                        else {
                            playerMediator.OnUseSkill(new SkillNormalAttack());
                            Debug.Log(" A技能 ");
                        }
                    }
                    else
                    {
                        if (listSkill[1].ToString() == "A")
                        {//BA
                            playerMediator.OnUseSkill(new SkillRollAttack());
                            Debug.Log(" BA  ");
                        }
                        else {
                            playerMediator.OnUseSkill(new SkillNormalRemoteAttack());
                            Debug.Log(" B技能 ");
                        }
                    }

                    break;
                }
            case 3:
                {
                    if (listSkill[0].ToString() == "A")
                    {
                        if (listSkill[1].ToString() == "A")
                        {
                            if (listSkill[2].ToString() == "B")
                            {
                                playerMediator.OnUseSkill(new SkillRangeRomateAttack());
                                Debug.Log("  AAB   ");
                            }
                            else
                            {
                                playerMediator.OnUseSkill(new SkillNormalAttack());
                                Debug.Log(" A技能 ");
                            }

                        }
                        else if (listSkill[2].ToString() == "A")
                        {
                            playerMediator.OnUseSkill(new SkillBigRemoteAttack());
                            Debug.Log("  ABA //向前闪现没找到  ");
                        }else {
                            playerMediator.OnUseSkill(new SkillNormalAttack());
                            Debug.Log(" A技能 ");
                        }
                    }
                    else
                    {//B*
                        if (listSkill[1].ToString() == "B")
                        {
                            if (listSkill[2].ToString() == "A")
                            {
                                playerMediator.OnUseSkill(new SkillBigRollAttack());
                                Debug.Log("  BBA   ");
                            }
                        }
                        else
                        {
                            playerMediator.OnUseSkill(new SkillNormalRemoteAttack());
                            Debug.Log(" B技能 ");
                        }
                    }
                    break;
                }
            case 4:
                {
                    if (listSkill[0].ToString() == "A")
                    {
                        if (listSkill[1].ToString() == "A")
                        {
                            if (listSkill[2].ToString() == "A")
                            {
                                if (listSkill[3].ToString() == "B")
                                {
                                    playerMediator.OnUseSkill(new SkillLightAttack());
                                    Debug.Log(" AAAB   ");
                                }
                            }
                            else
                            {//AAB
                                if (listSkill[3].ToString() == "B")
                                {
                                    playerMediator.OnUseSkill(new SkillCallRemoteAttack());
                                    Debug.Log(" AABB   ");
                                }
                            }
                        }
                        else
                        {//AB
                            if (listSkill[2].ToString() == "A")
                            {
                                if (listSkill[3].ToString() == "B")
                                {
                                    playerMediator.OnUseSkill(new SkillNormalRemoteAttack());
                                    Debug.Log(" ABAB  //加速没找到 ");
                                }
                            }
                            else
                            {//ABB

                                if (listSkill[3].ToString() == "B")
                                {
                                    playerMediator.OnUseSkill(new SkillNormalRemoteAttack());
                                    Debug.Log(" ABBA//加血没找到   ");
                                }
                            }
                        }
                    }
                    else//B*
                    {
                        if (listSkill[1].ToString() == "A")
                        {
                            if (listSkill[2].ToString() == "A")
                            {
                                if (listSkill[3].ToString() == "B")
                                {
                                    playerMediator.OnUseSkill(new SkillNormalRemoteAttack());
                                    Debug.Log(" BAAB  //无敌没找到 ");
                                }
                                else
                                {
                                    playerMediator.OnUseSkill(new SkillNormalRemoteAttack());
                                    Debug.Log(" B技能 ");
                                }


                            }
                            else
                            {
                                playerMediator.OnUseSkill(new SkillNormalRemoteAttack());
                                Debug.Log(" B技能 ");
                            }
                        }
                        else
                        {//BB*
                            if (listSkill[2].ToString() == "A")
                            {
                                if (listSkill[3].ToString() == "A")
                                {
                                    playerMediator.OnUseSkill(new SkillNormalRemoteAttack());
                                    Debug.Log("  BBAA //突击进攻不知道是哪个  ");
                                }
                                else
                                {
                                    playerMediator.OnUseSkill(new SkillNormalRemoteAttack());
                                    Debug.Log(" B技能 ");
                                }
                            }
                            else
                            {//BBB*
                                if (listSkill[3].ToString() == "A")
                                {
                                    playerMediator.OnUseSkill(new SkillRangeAttack());
                                    Debug.Log("  BBBA   ");
                                }
                                else
                                {
                                    playerMediator.OnUseSkill(new SkillNormalRemoteAttack());
                                    Debug.Log(" B技能 ");
                                }

                            }
                        }
                    }
                    break;
                }
            default:
                {
                    if (listSkill[0].ToString() == "A")
                    {

                        playerMediator.OnUseSkill(new SkillNormalAttack());
                        Debug.Log(" A技能 ");
                    }
                    else
                    {
                        playerMediator.OnUseSkill(new SkillNormalRemoteAttack());
                        Debug.Log(" B技能 ");
                    }
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


}
