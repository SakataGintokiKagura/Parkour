using UnityEngine;
using System.Collections;

public class Triggerrr : MonoBehaviour {
	public  GameObject trigger1;
//	public  GameObject trigger2;
//	public  GameObject trigger3;
	// Use this for initialization
	//public static int xxx;
	void Start () {

	}

	void Update () {
	
	}
	void OnTriggerEnter(Collider collider){
		//int RandKey = mankenum ();
		//int RandKey=11111;
		if(collider.tag=="Player"){
			//Debug.Log (1111);
			//Move.zhuangtai=1;
			if(this.gameObject.tag=="move1"){
				trigger1.gameObject.GetComponent<Move>().zhuangtai=4;
			}
			if(this.gameObject.tag=="move2"){
				trigger1.gameObject.GetComponent<Move>().zhuangtai=2;
			}
			if(this.gameObject.tag=="move3"){
				trigger1.gameObject.GetComponent<Move>().zhuangtai=1;
				//Debug.Log (111);
			}
		}

	}
	int mankenum(){
		int RandKey = Random.Range (0, 3);	
		return RandKey;
	}
	
}
