using UnityEngine;
using System.Collections;

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
    public AbsState[] sharedStates;

    public AbsState first;
    public AbsState second;
    public AbsState run;
    public AbsState general;
    public AbsState unInterrupted;
    public AbsState invincible;
    public AbsState unInvincible;

    public AbsState jumpState;
    public AbsState skillState;
    public AbsState hurtState;
    private PlayerState() {
        first = new FirstJump(this);
        second = new SecondJump(this);
        run = new Run(this);
        general = new GeneralSkill(this);
        unInterrupted = new UnInterruptedSkill(this);
        invincible = new Invincible(this);
        unInvincible = new UnInvincile(this);
        jumpState = run;
        skillState = run;
        hurtState = unInvincible;
    }

    public void OnJump() {
        jumpState = jumpState.OnJump();
    }

    public void OnGrounded() {
        jumpState = jumpState.OnGrounded();
    }

    public void OnUseSkill(bool isInterrupted)
    {
        skillState = skillState.OnUseSkill(isInterrupted);
    }

    public void OnEndSkill()
    {
        skillState = skillState.OnGrounded();

    }
    public void OnUnHurt()
    {
        hurtState = hurtState.OnJump();
    }
    public void OnHurt()
    {
        hurtState = hurtState.OnGrounded();
    }
}
