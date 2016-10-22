using UnityEngine;
using System.Collections;
/// <summary>
/// 朱科锦
/// 范围远程攻击
/// </summary>
public class RangeRomateAttack : MonoBehaviour {
	public float speedx;
	public float speedy;
	public float speedz;

	void Start () {
		transform.Translate(0,-speedx,0);
	}
	
	// Update is called once per frame
	/// <summary>
	/// 飞出屏幕时被销毁
	/// </summary>
	void Update () {
		transform.Translate(0,-speedx,0);
		if(Camera.main.WorldToViewportPoint(transform.position).x>1){
			Destroy (gameObject); 
			//Debug.Log(111);
		}
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag != TagParameber.monster)
        {
            return;
        }
        MonsterMediator.OnGetMonsterMediator().OnInjured(col.gameObject, new SkillRangeRomateAttack());
        Destroy(gameObject);
    }
}
