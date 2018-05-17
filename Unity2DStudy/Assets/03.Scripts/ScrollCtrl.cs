using UnityEngine;
using System.Collections;

public class ScrollCtrl : MonoBehaviour 
{
    public float amount = 54.6f; 
    // 충돌시에 그림을 밀어낼 양

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            // 그림을 amount만큼 넘겨라
            other.transform.position =
                new Vector3(
                    other.transform.position.x + amount,
                    other.transform.position.y,
                    other.transform.position.z);

        }

    }
}
