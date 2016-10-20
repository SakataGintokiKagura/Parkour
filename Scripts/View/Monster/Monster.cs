using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Monster : MonoBehaviour {
    private IMonsterMediator monsterMediator;
    
    void Start () {
        
	}
	// Update is called once per frame
	void Update () {
       
    }
    public void OnSetMonsterMediator(IMonsterMediator monsterMediator)
    {
        this.monsterMediator = monsterMediator;
    }
}
