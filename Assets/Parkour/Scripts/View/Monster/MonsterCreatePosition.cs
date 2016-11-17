using UnityEngine;
using System.Collections;
using CammerState;

public class MonsterCreatePosition : MonoBehaviour {

	private bool isCreateMonster ;
    private bool isContactTerrain ;
	private Vector3 position;
	private float count;
	private float y;
    private float monsterPosOffset;
    private float nearMonsterPosOffset;
    private float midMonsterPosOffset;
    private float farMonsterPosOffset;
    ReadTable table=ReadTable.getTable;
    private GameStates gameStatues;
	// Use this for initialization
	void Start () {
        gameStatues = GameStates.getInstance;
		isCreateMonster = true;
		isContactTerrain = true;
		count = gameObject.transform.position.x;
		y = 0;
	    nearMonsterPosOffset = float.Parse(table.OnFind("monsterParameber","11","Value"));
        midMonsterPosOffset = float.Parse(table.OnFind("monsterParameber", "12", "Value"));
        farMonsterPosOffset = float.Parse(table.OnFind("monsterParameber", "13", "Value"));
    }
	
	// Update is called once per frame
	void Update () {
        if (gameStatues.shareGameStates[1] is CreateMonsterState)
        {
            OnCreateMonter();
        }
       
	}
    /// <summary>
    /// 根据游戏状态机生成怪物
    /// </summary>
    void OnCreateMonter()
    {
       
        position = new Vector3(transform.position.x, y, transform.position.z);
        MonsterMediator.OnGetMonsterMediator().monsterCreatePosition = position;

        if (gameStatues.singleGameState is NearCammerState)
        {
            monsterPosOffset = nearMonsterPosOffset;
        }
        else if (gameStatues.singleGameState is MidCammerState)
        {
            monsterPosOffset = midMonsterPosOffset;
        }
        else
        {
            monsterPosOffset = farMonsterPosOffset;
        }
        if (gameObject.transform.position.x - count >= monsterPosOffset)
        {
            if (isCreateMonster && isContactTerrain)
            {
                if (gameObject.transform.position.x - count > monsterPosOffset+0.2)
                {
                    StartCoroutine(OnWait());
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
        yield return new WaitForSeconds(0.3f);
        if (isCreateMonster && isContactTerrain)
        {
            MonsterMediator.OnGetMonsterMediator().OnCreateMonster();
        }
    }
}
