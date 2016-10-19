using UnityEngine;
using System.Collections;
using System;

public class Monster : MonoBehaviour {
    private IMonsterMediator monsterMediator;
	//public GameObject ty;
	// Use this for initialization
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
