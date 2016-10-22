using UnityEngine;
using System.Collections;

public class BigRemoteAttack : MonoBehaviour {
	public float speedx;
	public float speedy;
	public float speedz;
	// Use this for initialization
	void Start () {
		transform.Translate(0,0,-speedx);
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.transform.rotation.x += speedx;
		transform.Translate(0,0,-speedx);
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
        MonsterMediator.OnGetMonsterMediator().OnInjured(col.gameObject, new SkillBigRemoteAttack());

    }
}
