using UnityEngine;
using System.Collections;

public abstract class IState {
	protected PlayerState player;
	public IState(PlayerState player){
		this.player = player;
	}
    public abstract IState OnJump(bool isJump);
    public abstract IState OnAttack(bool isAttack);
    public abstract IState OnGrounded();
}
