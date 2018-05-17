using UnityEngine;
using System.Collections;
using UnityEngine.UI;       // UI들의 컴포넌트를 얻어오기 위한 네임스페이스 추가 !
using UnityEngine.SceneManagement;  // SceneManager를 사용하기위한 네임스페이스 추가 !

public class GameController : MonoBehaviour 
{
    // Score, Game진행 등 전반적인 게임상황을 관리할 클래스
    // GameController라는 클래스는 이 클라이언트에서
    // 단 하나만 있으면된다 ! -> 싱글턴 디자인패턴

    // 멤버변수
    public static GameController current;
    // 정적 변수 : static 변수는 선언이 되면, 클래스가 종료되더라도 메모리가 계속 남아있다.
    // GameController라는 클래스에서는 current를 공용으로 사용한다.
    public GameObject gameOverText;
    public Text scoreText;
    bool isGameOver = false;
    int iScore = 0;

    // void Awake() : 유니티에서 예약된 함수
    // Start보다 먼저 호출된다. 해당 객체가 깨어났을때 단 한번만 호출이 되는 함수
    void Awake()
    {
        // 싱글턴 디자인 패턴
        if (current == null) // 비어있다면...
            current = this; // this : 본인의 주소값을 반환하는 키워드
        else if (current != null)
            Destroy(this.gameObject);   
        // 혹시나 객체가 하나더 만들어진다면, 삭제 처리 !
    }
	
	// Update is called once per frame
	void Update () 
    {
        // 게임오버가됬으면서, 아무키나 누른다면... ? 게임 처음으로 돌아간다 !
        if(isGameOver && Input.anyKey)
        {
            SceneManager.LoadScene("01.Main");
            // LoadScene(string); string에는 저장한 Scene파일의 이름을
            // 정확하게 넣어준다.
        }
	}

    public void BirdDied()
    {
        isGameOver = true;
        gameOverText.SetActive(true);   // 게임오버 텍스트를 킨다.
    }

    public void ScoreUp()
    {
        if(!isGameOver)
        {
            iScore += 100;      // iScore에 100점 추가
            scoreText.text = iScore.ToString(); 
            // VariableText의 Text영역을 iScore.ToString()한 값을 대입 !
        }
    }
}
