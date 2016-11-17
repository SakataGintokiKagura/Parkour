using UnityEngine;
using System.Collections;
using System.Reflection;

public class RemoteAttack : MonoBehaviour {
    private Rigidbody rig;
    private string ID;
	// Use this for initialization
	void Start () {
        ReadTable table = ReadTable.getTable;
        ID = gameObject.name;
        Vector3 temp = Vector3Tool.Parse(table.OnFind("flyItemDate", ID, "velocity"));
        rig = GetComponent<Rigidbody>();
        temp = transform.TransformVector(temp);
        rig.AddForce(temp, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
		if(Camera.main.WorldToViewportPoint(transform.position).x>1){
			MemoryController.instance.OnListAddObject(gameObject,MemoryParameter.FlyItemPriority);
		}
	}
	void OnTriggerEnter(Collider col) { 
		if (col.tag != TagParameber.monster)
		{
			return;
		}
        ReadTable temp = ReadTable.getTable;
        string name = temp.OnFind("flyItemDate", ID, "skillName");
        Assembly assembly = Assembly.GetExecutingAssembly();
        ISkill obj = (ISkill)assembly.CreateInstance(name);
        MonsterMediator.OnGetMonsterMediator().OnInjured(col.gameObject.transform.root.gameObject, obj);
		if (temp.OnFind ("flyItemDate", ID, "hide") == "Yes") {
			MemoryController.instance.OnListAddObject(gameObject, MemoryParameter.FlyItemPriority);
		}
	}
}
