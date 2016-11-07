using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = player.position.x + 5f;
        transform.position = temp;
        //Vector2 screenpos = Camera.main.WorldToScreenPoint(transform.position);//物体的世界坐标转化成屏幕坐标  
        //Vector3 e = Input.mousePosition;//鼠标的位置  


        ////当点击鼠标中键时  

        //if (Input.GetMouseButtonDown(2))
        //{
        //    Vector3 world;
        //    //e.z=screenpos.z;//1.因为鼠标的屏幕 Z 坐标的默认值是0，所以需要一个z坐标  
        //    //e.z=1;//将鼠标  
        //    //摄像机要垂直于x-z平面  
        //    //world=Camera.main.ScreenToWorldPoint(e);  
        //    world = new Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 106f);
        //    Vector3 world1 = Camera.main.ViewportToWorldPoint(new Vector3(world.x, world.y, 106f));
        //    //world.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;  
        //    //world.z = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;  
        //    //world.y = transform.position.y;  

        //    print("new x:" + world.x);
        //    print("new y:" + world.y);
        //    print("new z:" + world.z);
        //}
    }
}
