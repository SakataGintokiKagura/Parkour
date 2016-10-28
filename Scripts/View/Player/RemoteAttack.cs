using UnityEngine;
using System.Collections;
using System.Reflection;

public class RemoteAttack : MonoBehaviour {
    private Rigidbody rig;
    private string ID;
	// Use this for initialization
	void Start () {
        ReadTable table = ReadTable.getTable;
        for(int i = 1; i < 5; i++)
        {
            string name= table.OnFind("flyItemDate", i.ToString(), "name");
            if(gameObject.name == name + "(Clone)"|| gameObject.name == name)
            {
                ID = i.ToString();
                break;
            }
        }
        if (ID == "0")
            Debug.Log("飞行道具创建出错");
        Vector3 temp = Vector3Tool.Parse(table.OnFind("flyItemDate", ID, "velocity"));
        //temp.x *= 100;
        rig = GetComponent<Rigidbody>();
        temp = transform.TransformVector(temp);
        rig.AddForce(temp, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
      //  Debug.Log(rig.velocity);
		if(Camera.main.WorldToViewportPoint(transform.position).x>1){
			Destroy (gameObject); 
            
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
        MonsterMediator.OnGetMonsterMediator().OnInjured(col.gameObject,obj);
        //Debug.Log(temp.OnFind("flyItemDate", ID, "hide"));
        if(temp.OnFind("flyItemDate", ID, "hide") == "Yes")
            Destroy(gameObject);
	}
}
