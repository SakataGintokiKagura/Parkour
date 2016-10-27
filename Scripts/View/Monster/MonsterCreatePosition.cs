using UnityEngine;

public class MonsterCreatePosition : MonoBehaviour {

	private bool isCreateMonster = true;
    private bool isContactTerrain = true;
	private float count;
	// Use this for initialization
	void Start () { 
		count = gameObject.transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        MonsterMediator.OnGetMonsterMediator().monsterCreatePosition = transform;
        if (gameObject.transform.position.x-count>=10.0f) {
			count = gameObject.transform.position.x;
			if (isCreateMonster&&isContactTerrain) {
				MonsterMediator.OnGetMonsterMediator ().OnCreateMonster ();
			}
		}
	}

	void OnTriggerEnter(Collider other){
        //Debug.Log(33333);
		if(other.tag=="Coin")
			isCreateMonster = false;
        if (other.tag == "Terrain")
            isContactTerrain = true;
        
	}

	void OnTriggerExit(Collider other){
		if(other.tag=="Coin")
			isCreateMonster = true;
        if (other.tag == "Terrain")
            isContactTerrain = false;
    }
}
