using UnityEngine;
/// <summary>
/// 主角和怪物的信息接口
/// </summary>
public interface  IBlology  {
	int ID { get; set;}
    int HP { set; get; }
    int damage { set; get; }
    int normalAttackDistance { get; set; }
    bool hasAttack { get; set; }
}
