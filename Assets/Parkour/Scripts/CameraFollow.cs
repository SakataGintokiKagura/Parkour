using UnityEngine;
using System.Collections;
using DG.Tweening;
using NPlayerState;
using CammerState;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playertrans;
    [SerializeField]
    private Player player;
    private Vector3 velocity = Vector3.zero;
    private float lastPosition;
    private Transform camera;
    private Vector3 playerPosition;
    private float delta;
    private float replySpeed;
    private float verticalSpeed;
    private PlayerState playerState;
    private GameStates gameState;

    void Start()
    {
        camera = transform.FindChild("Main Camera");
        playerState = PlayerState.Instance;
        gameState = GameStates.getInstance;
        ReadTable table = ReadTable.getTable;
        playerPosition = Vector3Tool.Parse(table.OnFind("cameraParamber", "1", "dateValue"));
        delta = float.Parse(table.OnFind("cameraParamber", "2", "dateValue"));
        replySpeed = float.Parse(table.OnFind("cameraParamber", "3", "dateValue"));
        verticalSpeed = float.Parse(table.OnFind("cameraParamber", "4", "dateValue"));
        Vector3 position = Camera.main.ViewportToWorldPoint(playerPosition);
        position.y = 0;
        position.z = 0;
        playertrans.transform.position = position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        velocity.x = player.Velocity.x;
        transform.Translate(velocity);
        float xPosition = Camera.main.ViewportToWorldPoint(playerPosition).x;
        if (xPosition - playertrans.transform.position.x > delta)
        {
            transform.Translate(-velocity * replySpeed);
        }else if(xPosition - playertrans.transform.position.x < -delta)
        {
            transform.Translate(velocity * replySpeed);
        }
        if (!(gameState.singleGameState is FarCammerState))
            return;
        if(Mathf.Abs(player.Velocity.y-0) < delta && playerState.singletonState is Run)
        {
            float difference = playertrans.transform.position.y - transform.position.y;
            if (difference > delta)
            {
                float move = Mathf.Lerp(0, difference, verticalSpeed);
                transform.Translate(new Vector3(0,move,0));
            }
            else if (difference < -delta)
            {
                //Debug.Log(difference);
                float move = Mathf.Lerp(0, difference, verticalSpeed);
                transform.Translate(new Vector3(0, move, 0));
            }
            //Debug.Log(difference);
            //Debug.Log(transform.position.y - playertrans.transform.position.y);
        }
    }


    public void OnFlyFarPos()
    {
        transform.DOPath(MotionParameber.FarTargetPos, 1, PathType.CatmullRom).SetLoops(1).SetRelative(true);
    }

    public void OnFlyNearPos()
    {
        transform.DOPath(MotionParameber.nearTargetPos, 1, PathType.CatmullRom).SetLoops(1).SetRelative(true);
    }

    public void OnMidCamera()
    {

        camera.DOLocalMove(new Vector3(7.37f, 4.04f, -8.17f), 1,false);
        camera.DORotate(new Vector3(16.315f, -2.069f, 0.0f), 1,RotateMode.Fast);
    }

    public void OnNearCamera()
    {
        camera.DOLocalMove(new Vector3(7.37f, 4.67f, -6.86f), 1);
        camera.DOLocalRotate(new Vector3(20.385f, 0, 0.0f), 1, RotateMode.Fast);
    }

    public void OnFarCamera()
    {
        camera.DOLocalMove(new Vector3(9.229996f, 1.73f, -11.43f), 1,false);
        camera.DOLocalRotate(Vector3.zero, 1,RotateMode.Fast);
    }
}
