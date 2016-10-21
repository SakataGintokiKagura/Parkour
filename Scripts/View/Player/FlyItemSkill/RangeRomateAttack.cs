﻿using UnityEngine;
using System.Collections;

public class RangeRomateAttack : MonoBehaviour {
	public float speedx;
	public float speedy;
	public float speedz;

	void Start () {
		transform.Translate(0,-speedx,0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,-speedx,0);
		if(Camera.main.WorldToViewportPoint(transform.position).x>1){
			Destroy (gameObject); 
			//Debug.Log(111);
		}
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag != TagParameber.monster)
        {
            return;
        }
        MonsterMediator.OnGetMonsterMediator().OnInjured(col.gameObject, new SkillRangeRomateAttack());
        Destroy(gameObject);
    }
}