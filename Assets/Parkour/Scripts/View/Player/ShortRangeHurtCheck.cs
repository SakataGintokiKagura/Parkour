using UnityEngine;
using System.Collections;

public class ShortRangeHurtCheck : MonoBehaviour {
    [SerializeField]
    private Player skill;
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == TagParameber.monster)
        {
            MonsterMediator.OnGetMonsterMediator().OnInjured(col.gameObject, skill.Skill);
            if(skill.Skill is SkillBigRollAttack)
            {
                Rigidbody rig = col.gameObject.GetComponent<Rigidbody>();
                if (rig)
                    rig.AddForce(new Vector3(5, 4, -10), ForceMode.VelocityChange);
            }
        }
       
    }
}
