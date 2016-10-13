using UnityEngine;
using System.Collections;

public abstract class StateInterfance {
	protected PlayerState player;
	public StateInterfance(PlayerState player){
		this.player = player;
	}
    public abstract StateInterfance OnJump(bool isJump);
    public abstract StateInterfance OnAttack(bool isAttack);
    public abstract StateInterfance OnGrounded();
}
