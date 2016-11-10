using UnityEngine;
using System.Collections;

public class BOSS : MonoBehaviour {
	private int ID=1;
	private GameObject Gb;
	private Player Myplayer;
	private Vector3 velocity = Vector3.zero;
	private int hit=0;
	private float time=1;
	private int ontime;
	private float speedx;
	private float speedy;
	private float yup;
	private float ydown;
	private float biux;
	private float biuy;
	void Start () {
		ReadTable read = ReadTable.getTable;
		Vector3 tempp;
		tempp=Vector3Tool.Parse(read.OnFind("bossDate", "1", "coordinate"));
		Myplayer = PlayerMediator.OnGetPlayerMediator ().player;
		Gb=GameObject.Find("MonsterCreatePosition");
		Vector3 position = Camera.main.ViewportToWorldPoint(tempp);
//		position.y = 0;
//		position.z = 0;
		transform.position = position; 
		this.transform.parent = Gb.transform;
		ontime=int.Parse(read.OnFind("bossDate", "1", "time"));
		speedx = float.Parse (read.OnFind("bossDate", "1", "speedx"));
		speedy = float.Parse (read.OnFind("bossDate", "1", "speedy"));
		yup=float.Parse (read.OnFind("bossDate", "1", "yup"));
		ydown=float.Parse (read.OnFind("bossDate", "1", "ydown"));
		biux=float.Parse (read.OnFind("bossDate", "1", "biux"));
		biuy=float.Parse (read.OnFind("bossDate", "1", "biuy"));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(time>=ontime){
			time = 0;
			hit = stochastic ();
		}
		time += Time.deltaTime;
//		if (Input.GetKeyDown (KeyCode.V)) {
//			hit = 3;
//		}
//		if (Input.GetKeyDown (KeyCode.B)) {
//			hit = 1;
//		}
//		if (Input.GetKeyDown (KeyCode.N)) {
//			hit = 4;
//		}

		switch(hit){
		case 1:
			move ();
			break;
		case 2:
			back ();
			break;
		case 3:
			biu ();
			break;
//		case 4:
//			staticlaser ();
//			break;
		}

	}
	void move(){
		if (this.transform.position.y >= ydown) {
			this.transform.position = new Vector3 (transform.position.x - speedx, transform.position.y - speedy, transform.position.z);
		} else {
			hit = 2;
		}
	}
	void back(){
		if (this.transform.position.y <= yup) {
			this.transform.position = new Vector3 (transform.position.x + speedx, transform.position.y + speedy, transform.position.z);
		} else {
			hit = 0;
		}
	}
	void OnTriggerEnter(Collider collider){
		if(collider.tag=="Player"){
			Debug.Log (transform.position);
			hit = 2;
			}
		}
	void biu(){
		GameObject temp = Resources.Load("Monster/Bossskill") as GameObject;
		GameObject biuu=Instantiate(temp, new Vector3(0,1000,0), temp.transform.rotation)as GameObject;
		biuu.transform.parent = this.transform;
		biuu.transform.position = new Vector3 (this.transform.position.x+biux,this.transform.position.y+biuy,this.transform.position.z);
		hit = 0;
	}
//	void staticlaser(){
//		GameObject temp = Resources.Load("Monster/BOSSSKILL/staticlaser") as GameObject;
//		GameObject claser =Instantiate(temp, new Vector3(0,1000,0), temp.transform.rotation)as GameObject;
//		claser.transform.parent = this.transform;
//		claser.transform.position = new Vector3 (this.transform.position.x-1,this.transform.position.y+1,this.transform.position.z);
//		hit = 0;
//	}
	int  stochastic(){
		int t;
		t = Random.Range (1,4);
		return t;
	}
}
