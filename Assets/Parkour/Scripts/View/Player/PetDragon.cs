using UnityEngine;
using System.Collections;

public class PetDragon : MonoBehaviour {
    // Use this for initialization
    private Transform playerTransform;
    private Vector3 endPosition;
    private bool isHasAttack;
    private bool attacking;
    private float delta;
    private float startdelta;
    private float deltaSpeed;
    private float hight;
    private float attackTime;
    private float targetDelta;
    private Collider hurt;
    [SerializeField]
    private GameObject fire;
	void Start () {
        ReadTable table = ReadTable.getTable;
        playerTransform = PlayerMediator.OnGetPlayerMediator().player.transform;
        transform.position = playerTransform.position + Vector3Tool.Parse(table.OnFind("PetParaember","1", "dateValue"));
        hurt = GetComponent<Collider>();
        endPosition = Vector3Tool.Parse(table.OnFind("PetParaember", "2", "dateValue"));
        hight = float.Parse(table.OnFind("PetParaember", "3", "dateValue"));
        startdelta =float.Parse(table.OnFind("PetParaember", "4", "dateValue"));
        delta = startdelta;
        deltaSpeed = float.Parse(table.OnFind("PetParaember", "5", "dateValue"));
        attackTime = float.Parse(table.OnFind("PetParaember", "6", "dateValue"));
        targetDelta = float.Parse(table.OnFind("PetParaember", "7", "dateValue"));
    }
    void FixedUpdate()
    {
        Vector3 targetPosition;
        if (isHasAttack)
            targetPosition = playerTransform.position +endPosition;
        else
            targetPosition = new Vector3(playerTransform.position.x,hight,0);
        transform.position = Vector3.Lerp(transform.position, targetPosition, delta);
        if (isHasAttack && (Camera.main.WorldToViewportPoint(transform.position).y > 1f))
            OnDisappear();
        if (Mathf.Abs(transform.position.x - targetPosition.x) < targetDelta&&!attacking)
        {
            StartCoroutine(OnAttack(attackTime));
        }
        delta += deltaSpeed;
    }
    IEnumerator OnAttack(float time)
    {
        attacking = true;
        fire.SetActive(true);
        hurt.enabled = true;
        yield return new WaitForSeconds(time);
        fire.SetActive(false);
        isHasAttack = true;
        hurt.enabled = false;
        delta = startdelta;
    }
    void OnDisappear()
    {
        attacking = isHasAttack = false;
		MemoryController.instance.OnListAddObject (gameObject,MemoryParameter.PetPriority);
        delta = startdelta;
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == TagParameber.monster)
        {
            MonsterMediator.OnGetMonsterMediator().OnInjured(col.gameObject, new SkillCallRemoteAttack());
        }
    }
}
