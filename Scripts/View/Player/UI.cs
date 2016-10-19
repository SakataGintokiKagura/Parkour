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
        
	}
    public void OnSetPlayerMediator(IPlayerMediator playerMediator)
    {
        this.playerMediator = playerMediator;
    }
}
