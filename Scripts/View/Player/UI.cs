using UnityEngine;
using System.Collections;
using System;
public class UI : MonoBehaviour {
    private IPlayerMediator playerMediator;
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMediator.OnJump();
            //playerMediator.OnUseSkill(new Jump());
            //playerMediator.OnInjured();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerMediator.OnUseSkill(new SkillNormalAttack());
        }

	}
    public void OnSetPlayerMediator(IPlayerMediator playerMediator)
    {
        this.playerMediator = playerMediator;
    }
}
