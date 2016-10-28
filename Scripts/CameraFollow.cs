using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform player;
	// Update is called once per frame
	void Update () {
		Vector3 temp = transform.position;
		temp.x = player.position.x+5f;
		transform.position = temp;
	}
}
