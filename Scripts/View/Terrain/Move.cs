using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public int  zhuangtai;
	private float speedx=0.05f;
	private float speedy=0.08f;
	private float heng;
	//private Triggerrr tri;
	// Use this for initialization
	void Start () {
		heng = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		//zhuangtai = tri.xxx;
		if (zhuangtai == 1) {
			transform.Translate (new Vector3(speedx,0,0));
			if (this.transform.position.x >= heng + 5) {
				zhuangtai = 0;
			}
		}
		if (zhuangtai == 2) {
			transform.Translate (0,speedy,0);
			if (gameObject.name == "0") {
				if(this.transform.position.y>=-1){
					zhuangtai = 0;
				}
			}
			if (gameObject.name == "3") {
				if(this.transform.position.y>=0.5f){
					zhuangtai = 0;
				}
			}
		}
//		if (zhuangtai == 3) {
//			transform.Translate (0,speedy,0);
//			if(this.transform.position.y>=0.5f){
//				zhuangtai = 0;
//			}
//		}
		if (zhuangtai == 4) {
			transform.Translate (0,-speedy,0);
			if (gameObject.name == "0") {
				if(this.transform.position.y<-10){
					zhuangtai = 0;
				}
			}
			if (gameObject.name == "6") {
				if(this.transform.position.y<-2.5){
					zhuangtai = 0;
				}
			}
			if (gameObject.name == "3") {
				if(this.transform.position.y<-4){
					zhuangtai = 0;
				}
			}
		}
	}
}
