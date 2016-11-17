using UnityEngine;
using System.Collections;

public class rabbitbullet : MonoBehaviour {
    Player player;
    Rigidbody rig;
    [SerializeField]
    GameObject boom;
	// Use this for initialization
	void Start () {
        player = PlayerMediator.OnGetPlayerMediator().player;
        rig = GetComponent<Rigidbody>();
        Vector3 direction = player.transform.position - transform.position;
        rig.AddForce(direction * 20);
	}
    void OnCollisionEnter(Collision col)
    {
        boom.SetActive(true);
        StartCoroutine(OnDestroy());
    }
    IEnumerator OnDestroy()
    {
        boom.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
