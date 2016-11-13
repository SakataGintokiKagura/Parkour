using System;
using System.Collections.Generic;
using System.Reflection;

namespace NPlayerState
{
    public class PlayerState
    {
        private static PlayerState instance;
        public AbsState[] sharedStates = new AbsState[2];

        public AbsState singletonState;

        public List<AbsState> stateList = new List<AbsState>();
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
        private PlayerState()
        {
            var ty = GetTypes();
            foreach (var item in ty)
                stateList.Add((AbsState) Activator.CreateInstance(item, this));
            //string appPath = Directory.GetCurrentDirectory();
            //appPath += "\\Assets\\Parkour\\Scripts\\Model\\PlayerState";
            //DirectoryInfo dir = new DirectoryInfo(appPath);
            //if (dir.Exists)
            //{
            //    FileInfo[] fiList = dir.GetFiles();
            //    foreach (var item in fiList)
            //    {
            //        //Debug.Log(item.FullName);
            //        //Debug.Log(item.Name);     //文件名加后缀
            //        string[] name = item.Name.Split('.');
            //        if (name.Length < 3 && name[1] == "cs" && (name[0] != "AbsState" && name[0] != "PlayerState"))
            //        {
            //            Type t = Type.GetType(name[0]);
            //            stateList.Add((AbsState)Activator.CreateInstance(t, this));
            //        }
            //    }
            //}
            //first = new FirstJump(this);
            //second = new SecondJump(this);
            //run = new Run(this);
            //general = new GeneralSkill(this);
            //unInterrupted = new UnInterruptedSkill(this);
            //invincible = new Invincible(this);
            //unInvincible = new UnInvincile(this);
            foreach (var item in stateList)
                if (item is Run)
                    singletonState = item;
                else if (item is UnInvincile)
                    sharedStates[1] = item;
        }

        public static PlayerState Instance
        {
            get
            {
                if (instance == null)
                    instance = new PlayerState();
                return instance;
            }
        }

        public List<Type> GetTypes()
        {
            var lt = new List<Type>();
            try
            {
                foreach (var item in Assembly.GetExecutingAssembly().GetTypes())
                    if ((item.Namespace == GetType().Namespace) && (item != GetType()))
                        lt.Add(item);
            }
            catch
            {
            }
            return lt;
        }

        public void OnJump()
        {
            singletonState = singletonState.OnJump();
        }

        public void OnGrounded()
        {
            singletonState = singletonState.OnGrounded();
            if (sharedStates[0] is UnUseSkill)
                sharedStates[0] = sharedStates[0].OnGrounded();
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
            if (singletonState is Run)
                sharedStates[0] = sharedStates[0].OnGrounded();
            else
                sharedStates[0] = sharedStates[0].OnJump();
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
}