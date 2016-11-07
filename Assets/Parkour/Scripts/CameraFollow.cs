using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playertrans;
    [SerializeField]
    private Player player;
    private Vector3 velocity = Vector3.zero;
    private float lastPosition;

    private Vector3 playerPosition;
    private float delta;
    private float replySpeed;
    void Start()
    {
        ReadTable table = ReadTable.getTable;
        playerPosition = Vector3Tool.Parse(table.OnFind("cameraParamber", "1", "dateValue"));
        delta = float.Parse(table.OnFind("cameraParamber", "2", "dateValue"));
        replySpeed = float.Parse(table.OnFind("cameraParamber", "3", "dateValue"));

        Vector3 position = Camera.main.ViewportToWorldPoint(playerPosition);
        position.y = 0;
        position.z = 0;
        playertrans.transform.position = position;
        lastPosition = position.x;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        velocity.x = player.Velocity.x;
        transform.Translate(velocity);
        float xVelocity = transform.position.x - lastPosition;
        if(player.Velocity.x - xVelocity< delta)
            if (Camera.main.ViewportToWorldPoint(playerPosition).x - playertrans.transform.position.x > 0.5f)
            {
                transform.Translate(-velocity * replySpeed);
            }
    }
}
