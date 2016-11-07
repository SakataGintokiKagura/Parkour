using UnityEngine;
/// <summary>
/// 主角和怪物的信息接口
/// </summary>
public interface IBlology
{
    int ID { get; set; }
    int HP { set; get; }
    int damage { set; get; }
    int normalAttackDistance { get; set; }
    /// <summary>
    /// 出现在屏幕之中
    /// </summary>
    /// <param name="tran"></param>
    void OnInView(Transform tran);
    /// <summary>
    /// 在攻击范围里面，攻击敌人
    /// </summary>
    /// <param name="tran"></param>
    void OnAttack(Transform tran);

    /// <summary>
    /// 离开攻击范围
    /// </summary>
    void OnOutOfAttack(Transform tran);
    /// <summary>
    /// 离开屏幕
    /// </summary>
    /// <param name="tran"></param>
    void OnOutView(Transform tran);
}
