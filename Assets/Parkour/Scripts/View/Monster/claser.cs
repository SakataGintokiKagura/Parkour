using UnityEngine;
using System.Collections;

public class claser : MonoBehaviour {
	public GameObject cube1;
	public GameObject cube2;
	private GameObject cube;
	int tt=0;
	int ontime;
	private Player Myplayer;
	// Use this for initialization
	void Start () {
		Myplayer = PlayerMediator.OnGetPlayerMediator ().player;
		if (Myplayer.transform.position.y < 0) {
			cube = cube2;
		} else {
			cube = cube1;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ontime++;
		if(ontime>=30){
		int t = num (tt);
		tt = t;
		if (t == 0) {
			cube.active = false;
			//Debug.Log (111);
		} else {
			cube.active = true;
			//Debug.Log (222);
		}
		}
		if(ontime>=60){
			Destroy (this.gameObject);
		}
	}
	int num(int t){
		if (t == 0) {
			t = 1;
		} else {
			t = 0;
		}
		return t;
	}
}
