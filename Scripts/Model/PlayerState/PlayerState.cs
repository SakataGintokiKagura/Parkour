using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class PlayerState  {
    private static PlayerState instance;
    public static PlayerState Instance {
        get {
            if (instance == null) {
                instance = new PlayerState();
            }
            return instance;
        }
    }
    public AbsState singletonState;
    public AbsState[] sharedStates = new AbsState[2];

    public List<AbsState> stateList;
    //public AbsState first;
    //public AbsState second;
    //public AbsState run;
    //public AbsState general;
    //public AbsState unInterrupted;
    //public AbsState invincible;
    //public AbsState unInvincible;

    //public AbsState jumpState;
    //public AbsState skillState;
    //public AbsState hurtState;
    private PlayerState() {
        stateList = new List<AbsState>();
        //string appPath = Application.dataPath;
        //appPath += "/Parkour/Scripts/Model/PlayerState";
        string appPath = Directory.GetCurrentDirectory();
        appPath += "\\Assets\\Parkour\\Scripts\\Model\\PlayerState";
        DirectoryInfo dir = new DirectoryInfo(appPath);
        if (dir.Exists)
        {
            FileInfo[] fiList = dir.GetFiles();
            foreach (var item in fiList)
            {
                //Debug.Log(item.FullName);
                //Debug.Log(item.Name);     //文件名加后缀
                string[] name = item.Name.Split('.');
                if(name.Length<3&&name[1] == "cs" && (name[0] != "AbsState"&&name[0]!="PlayerState"))
                {
                    Type t = Type.GetType(name[0]);
                    stateList.Add((AbsState)System.Activator.CreateInstance(t,this));
                }
            }
        }
        //first = new FirstJump(this);
        //second = new SecondJump(this);
        //run = new Run(this);
        //general = new GeneralSkill(this);
        //unInterrupted = new UnInterruptedSkill(this);
        //invincible = new Invincible(this);
        //unInvincible = new UnInvincile(this);
        foreach(var item in stateList)
        {
            if(item is Run)
            {
                singletonState = item;
            }else if(item is UnInvincile)
            {
                sharedStates[1] = item;
            }
        }
    }

    public void OnJump() {
        singletonState = singletonState.OnJump();
    }

    public void OnGrounded() {
        singletonState = singletonState.OnGrounded();
    }

    public void OnUseSkill(bool isInterrupted)
    {
        if (sharedStates[0] == null)
            sharedStates[0] = singletonState.OnUseSkill(isInterrupted);
        else
            sharedStates[0] = sharedStates[0].OnUseSkill(isInterrupted);
    }

    public void OnEndSkill()
    {
        sharedStates[0] = sharedStates[0].OnGrounded();
    }
    public void OnUnHurt()
    {
        sharedStates[1] = sharedStates[1].OnJump();
    }
    public void OnHurt()
    {
        sharedStates[1] = sharedStates[1].OnGrounded();
    }
}
