using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
/// <summary>
/// 卢平原 怪物生成算法
/// </summary>
public class MonsterCreate : SimpleCommand
{

    public new const string NAME = "MonsterCreate";

    public override void Execute(INotification notification)
    {
        //Debug.Log(1111);
        if (Random.Range(0, MonsterParameber.GeneratingprobabilityMax) < MonsterParameber.GeneratingprobabilityMin)
        {
            MonsterProxy monster = (MonsterProxy)Facade.RetrieveProxy(MonsterProxy.NAME);
            //Debug.Log(222);
            monster.OnCreatMonster((MonsterEnum)Random.Range(0, MonsterParameber.SpeciesNumber), 1);
        }
    }
}
