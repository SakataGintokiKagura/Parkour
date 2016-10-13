using UnityEngine;
using System.Collections;
using System;

public class SecondJump : StateInterfance {
    public SecondJump(PlayerState player) : base(player)
    {
    }

    public override StateInterfance OnAttack(bool isAttack)
    {
        throw new NotImplementedException();
    }

    public override StateInterfance OnGrounded()
    {
        return player.run;
    }

    public override StateInterfance OnJump(bool isJump)
    {
        return player.second;
    }
}
