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
    public IState first;
    public IState second;
    public IState run;

    public IState jumpState;
    public IState skillState;
    private PlayerState() {
        first = new FirstJump(this);
        second = new SecondJump(this);
        run = new Run(this);
        jumpState = run;
    }

    public void OnJump(bool isJump) {
        jumpState = jumpState.OnJump(isJump);
    }

    public void OnGrounded() {
        jumpState = jumpState.OnGrounded();
    }
}
