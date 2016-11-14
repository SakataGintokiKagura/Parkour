using UnityEngine;
using System.Collections;
using CammerState;
public abstract class AbsGameState
{
    protected GameStates gameState;

    public AbsGameState(GameStates gameState)
    {
        this.gameState = gameState;
    }

    public abstract AbsGameState OnChangeWay(bool isNear);
    public abstract AbsGameState OnCreatBoss();
    public abstract AbsGameState OnCancleBoss();
}
