using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour 
{
    public Transform target;    // 플레이어의 정보
    public float xOffset;       // x쪽 일정 거리
    // 플레이어의 위치값을 받으면된다.
    // 어떻게 ? 
    // 1. Player GameObject 인스턴스화 된 주소값을 얻어와서 찾아야한다.
    // 2. public으로 노출시킨다.
	
	// Update is called once per frame
	void Update () 
    {
        //GetComponent<Transform>(); == transform;
        transform.position = new Vector3(
            target.position.x + xOffset,
            transform.position.y,
            transform.position.z);
        // 본인(Camera)의 위치(transform.position)를 매 프레임마다(Update)
        // target(Player)의 위치에 따라 변경을 하겠다.
	}
}
