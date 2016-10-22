using UnityEngine;
using System.Collections;
/// <summary>
/// 朱科锦
/// 光线远程攻击
/// </summary>
public class LightAttack : MonoBehaviour {
	public float speedx;
	public float speedy;
	public float speedz;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/// <summary>
	/// 飞出屏幕时被销毁
	/// </summary>
	void Update () {
		transform.Translate(0,0,speedx);

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
        MonsterMediator.OnGetMonsterMediator().OnInjured(col.gameObject, new SkillLightAttack());

    }
}
