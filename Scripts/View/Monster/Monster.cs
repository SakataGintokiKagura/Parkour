using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Monster : MonoBehaviour {
    private IMonsterMediator monsterMediator;
<<<<<<< HEAD
    
    void Start () {
        
	}
	// Update is called once per frame
	void Update () {
       
    }
=======
	//public GameObject ty;
	// Use this for initialization
	void Start () {
	    
	}
	// Update is called once per frame
	void Update () {

	}
>>>>>>> origin/master
    public void OnSetMonsterMediator(IMonsterMediator monsterMediator)
    {
        this.monsterMediator = monsterMediator;
    }
}
