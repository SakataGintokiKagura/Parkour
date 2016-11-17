using UnityEngine;
using System.Collections;

public class RabbitBoss : MonoBehaviour
{
    float attackTimeBig;
    float attackTimeSmall;
    float warningTime;
    float attackSpeed;
    float vibrationRange;
    float vibrationSpeed;
    float yVibrationDelta;
    float xVibrationDelta;
    float arriveSpeed;
    bool isArrive;
    bool isAttacking;
    Vector3 targetPosition;
    Vector3 targetPositionCamera;
    Animator anim;
    Rigidbody rig;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bulletPosition;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        ReadTable table = ReadTable.getTable;
        targetPositionCamera = Vector3Tool.Parse(table.OnFind("WaSiBoss", "8", "dateValue"));
        targetPosition = Camera.main.ViewportToWorldPoint(targetPositionCamera);
        targetPosition.y = 0;
        targetPosition.z = 0;
        transform.parent = GameObject.Find("CameraMove").transform;
        attackTimeBig = int.Parse(table.OnFind("WaSiBoss", "1", "dateValue"));
        attackTimeSmall = float.Parse(table.OnFind("WaSiBoss", "2", "dateValue"));
        warningTime = float.Parse(table.OnFind("WaSiBoss", "3", "dateValue"));
        attackSpeed = float.Parse(table.OnFind("WaSiBoss", "4", "dateValue"));
        vibrationRange = float.Parse(table.OnFind("WaSiBoss", "5", "dateValue"));
        vibrationSpeed = float.Parse(table.OnFind("WaSiBoss", "6", "dateValue"));
        arriveSpeed = float.Parse(table.OnFind("WaSiBoss", "7", "dateValue"));
        StartCoroutine(OnAttack());
    }

    // Update is called once per frame
    void Update()
    {
        //if (isAttacking)
        ////    return;
        if (!isArrive)
        {
            targetPosition.x = Camera.main.ViewportToWorldPoint(targetPositionCamera).x;
            transform.position = Vector3.Lerp(transform.position, targetPosition, arriveSpeed);
            if (Mathf.Abs(transform.position.x - targetPosition.x) < 0.05f)
                isArrive = true;
        }
        else
        {
            transform.Translate(new Vector3(0, vibrationSpeed, 0));
            yVibrationDelta += vibrationSpeed;
            transform.Translate(new Vector3(0, 0, vibrationSpeed));
            xVibrationDelta += vibrationSpeed;
            if (Mathf.Abs(yVibrationDelta) > vibrationRange)
                vibrationSpeed = -1 * vibrationSpeed;
            if (Mathf.Abs(yVibrationDelta) > vibrationRange)
                xVibrationDelta = -1 * vibrationSpeed;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == TagParameber.terrain)
        {
            rig.AddForce(Vector3.up * 6, ForceMode.VelocityChange);
            anim.SetInteger("Jump", 1);
        }
        if (col.tag == TagParameber.coin)
            col.gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == TagParameber.terrain)
            anim.SetInteger("Jump", 0);
    }
    IEnumerator OnAttack()
    {
        while (true)
        {
            float attackTime = Random.Range(attackTimeSmall, attackTimeBig);
            yield return new WaitForSeconds(attackTime);
            anim.SetTrigger("Attack");
            yield return new WaitForSeconds(0.2f);
            Instantiate(bullet,bulletPosition.position,bulletPosition.rotation);
        }
    }

    //IEnumerator OnAttackMelee()
    //{
    //    //isAttacking = true;
    //    ////Vector3 InitialPosition = transform.InverseTransformVector(transform.position);
    //    //Vector3 playerPosition = PlayerMediator.OnGetPlayerMediator().player.transform.position;
    //    //playerPosition.y = -1;
    //    //Vector3 delta = playerPosition - transform.position;
    //    //delta.z = 0;
    //    //float xAfter = 0;
    //    //bool isNear = false;
    //    //while (true)
    //    //{
    //    //    if (!isNear)
    //    //    {
    //    //        transform.Translate(delta * MotionParameber.fixedMotion * attackSpeed);
    //    //        xAfter += delta.x * MotionParameber.fixedMotion * attackSpeed;
    //    //        yield return new WaitForFixedUpdate();
    //    //        if (Mathf.Abs(delta.x - xAfter) < 1f)
    //    //        {

    //    //            xAfter = 0;
    //    //            isNear = true;
    //    //        }
    //    //    }
    //    //    else
    //    //    {
    //    //        transform.Translate(-1 * delta * MotionParameber.fixedMotion * attackSpeed);
    //    //        xAfter += delta.x * MotionParameber.fixedMotion * attackSpeed;
    //    //        yield return new WaitForFixedUpdate();
    //    //        if (Mathf.Abs(delta.x - xAfter) < 1f)
    //    //        {
    //    //            isAttacking = false;
    //    //            break;
    //    //        }
    //    //    }
    //    //}
    //}
}
