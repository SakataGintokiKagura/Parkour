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
        if (gameObject.transform.position.x-count>=15f) {

//			

            if (isCreateMonster && isContactTerrain)
            {
                if (gameObject.transform.position.x - count > 15.5f)
                {
                   StartCoroutine(OnWait()) ;
                }
                else
                {
                    MonsterMediator.OnGetMonsterMediator().OnCreateMonster();
                }
               
               
                count = gameObject.transform.position.x;
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

    IEnumerator OnWait()
    {
        yield return new WaitForSeconds(0.07f);
        MonsterMediator.OnGetMonsterMediator().OnCreateMonster();
    }
}
