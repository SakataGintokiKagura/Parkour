using UnityEngine;
using System.Collections;

public class BOSS : MonoBehaviour {
	private  Player Myplayer;
	public  static int time;
	public  static int ontime = 0;
	public  static float xx;
	public  static float yy;
	public  static int RandKey;
	// Use this for initialization
	void Start () {
		Myplayer = PlayerMediator.OnGetPlayerMediator ().player;
	    time = 0;
		xx = 7;
		yy = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ontime++;
		if (ontime > 100) {
		   RandKey = Random.Range(0,3);
		   ontime = 0;
		}




		if (RandKey==1) {
			time = 1;
			RandKey = 0;
		}
		if(time==0){
		    gameObject.transform.position =new Vector3( Myplayer.gameObject.transform.position.x+7,1.5f,0);
			//Debug.Log(gameObject.transform.position);
		}
		if(time==1){
			yy += 0.25f;
			xx -= 0.5f;
			gameObject.transform.position =new Vector3( Myplayer.gameObject.transform.position.x+xx,1.5f-yy,0);
			//Debug.Log (gameObject.transform.position);
		}
		if(gameObject.transform.position.y<=-1.5f){
			time = 2;
		}
		if(time==2){
			yy -= 0.25f;
			xx += 0.5f;
			gameObject.transform.position =new Vector3( Myplayer.gameObject.transform.position.x+xx,1.5f-yy,0);
			if (gameObject.transform.position.y>=1.5f) {
				time = 0;
			}
		}
		if (RandKey==2) {
			GameObject skill=GameObject.Instantiate 
				(Resources.Load("Monster/Bossskill"),new Vector3(gameObject.transform.position.x+1.5f,5,0),
					new Quaternion(0,0,0.89f,0.46f))as GameObject;
			RandKey = 0;
		}
	}
}
