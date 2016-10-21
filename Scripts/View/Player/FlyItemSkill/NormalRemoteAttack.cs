using UnityEngine;
using System.Collections;

public class NormalRemoteAttack : MonoBehaviour {
	public float speedx;
	public float speedy;
	public float speedz;
	// Use this for initialization
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
    void OnTriggerEnter(Collider col) { 
        if (col.tag != TagParameber.monster)
        {
            return;
        }
        MonsterMediator.OnGetMonsterMediator ().OnInjured (col.gameObject,new SkillNormalRemoteAttack());
        Destroy(gameObject);

	}


	//Renderer.isvisible
}
