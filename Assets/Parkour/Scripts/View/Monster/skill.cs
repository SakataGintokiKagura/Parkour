using UnityEngine;
using System.Collections;

public class skill : MonoBehaviour {
	public float speedx=0.43f;
	public float speedy;
	public float speedz;
	// Use this for initialization
	void Start () {
		transform.Translate(0,speedx,0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,speedx,0);
		if(transform.position.y<0){
			Destroy (gameObject); 
			//Debug.Log(111);
		}
	}
}
