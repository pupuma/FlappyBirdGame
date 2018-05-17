using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;  // Scene Manager를 사용하기 위해 네임스페이스 추가

public class LogoController : MonoBehaviour 
{
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.anyKey)
        {
            SceneManager.LoadScene("01.Main");
        }
	}
}
