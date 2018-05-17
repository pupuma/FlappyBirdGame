using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour 
{
    public float forwardSpeed;  // 새가 날라가는 속도
    public float UpForce;       // 키입력을 했을때 위로 줄 힘
    public bool isDead = false; // 플레이어가 죽었는지 살았는지...
    bool flap = false;          // 키 입력 체크
    Animator anim;              // Animator 컴포넌트를 담을 공간

    /*
     - class의 속성중 하나인 "정보은폐성"에 따라
     class내부를 접근할때 "접근제한자" public의 경우
     내부 또는 외부 전부 접근할 수 있는 권한을 주겠다. 라고 표현
     이외 private, protected 등등
     - 생략을 했을경우, 기본 private:으로 지정이된다.
     - 유니티에서 public으로 변수를 선언했을때, UI에 노출이 되고,
     변수의 데이터 초기화시에 유니티 UI가 우선권을 가지고있다.
     */

	// Use this for initialization
	void Start () 
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(forwardSpeed, 0.0f);
        // Vector : 방향과 크기를 가지고있는 물리량
        // 좌표계(x, y, z)
        // Rigidbody2D컴포넌트의 velocity항목에 x의 속도 : forwardSpeed만큼,
        // y의 속도를 0.0f로 줬다.

        anim = GetComponent<Animator>();    // 현재 객체가 가지고있는
                                            // Animator라는 컴포넌트를 가져와서 
                                            // anim 담아라
	}

    // FixedUpdate : 전Frame과 현Frame의 시간차이가 일정하게 하고 통일화된 DeltaTime
    // 에 따라 함수가 호출이된다. -> Frame에 상관없이 시간에따라 일정하게 호출이된다.
    // -> 물리량 조절할때 많이 쓴다.
    void FixedUpdate()
    {
        if(flap)
        {
            flap = false;

            anim.SetTrigger("isFlap");
            // SetTrigger(string); Animator Controller의 파라메터를 조작할 수 있는 함수
            // Trigger 파라메터를 설정할 수 있다.
            // "isFlap"이라는 방아쇠를 당겨라 !

            // 중력값을 초기화을 위해 y의 속도값 제거(x값은 그대로 유지)
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0.0f);

            // 위로 점프
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, UpForce));
        }
    }

	
	// Update is called once per frame
	void Update () 
    {
        if (isDead)
            return;

        if (Input.anyKeyDown)   // 키 체크
            flap = true;
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        anim.SetTrigger("isDie");
        isDead = true;

        GameController.current.BirdDied(); 
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //int iScore = 0; 
        // 지역변수 { }에서 선언된 변수 !
        // 지역변수는 지역이 끝나면 메모리가 반환된다.

        if (other.tag == "ColumnBlock")
            GameController.current.ScoreUp();
    }
}
