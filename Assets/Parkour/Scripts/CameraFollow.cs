using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playertrans;
    [SerializeField]
    private Player player;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(0.35f, 0.2f, 11.7f));
        position.y = 0;
        position.z = 0;
        playertrans.transform.position = position; 
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        velocity.x = player.Velocity.x;
        transform.Translate(velocity);
    }
}
