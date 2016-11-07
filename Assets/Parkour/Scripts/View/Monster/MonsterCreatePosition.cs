using UnityEngine;
using System.Collections;

public class MonsterCreatePosition : MonoBehaviour {

	private bool isCreateMonster = true;
    private bool isContactTerrain = true;
	private Vector3 position;
	private float count;
	private float y;
	// Use this for initialization
	void Start () { 
		count = gameObject.transform.position.x;
		y = 0;
    }
	
	// Update is called once per frame
	void Update () {
		position = new Vector3 (transform.position.x,y,transform.position.z);
		MonsterMediator.OnGetMonsterMediator().monsterCreatePosition = position;
        if (gameObject.transform.position.x-count>=10.0f) {
			count = gameObject.transform.position.x;
			if (isCreateMonster&&isContactTerrain) {
				MonsterMediator.OnGetMonsterMediator ().OnCreateMonster ();
			}
		}
	}

	void OnTriggerStay(Collider other){
		if(other.tag=="Coin")
			isCreateMonster = false;
		if (other.tag == "Terrain") {
			isContactTerrain = true;
			y = float.Parse (other.name.ToString ());
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag=="Coin")
			isCreateMonster = true;
        if (other.tag == "Terrain")
            isContactTerrain = false;
    }
}
