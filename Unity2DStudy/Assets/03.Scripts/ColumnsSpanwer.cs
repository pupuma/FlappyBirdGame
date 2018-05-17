using UnityEngine;
using System.Collections;

public class ColumnsSpanwer : MonoBehaviour 
{
    public GameObject columnPrefab; // 생성할 프리팹의 정보
    public int columnPoolSize = 5;  // 미리 생성해놓을 기둥의 수
    public float spawnRate = 5.0f;  // 몇 초마다 생성 할꺼냐?
    public float columnMin = -1.0f; // 랜덤으로 생성할 기둥의 y최소값
    public float columnMax = 3.5f;  // 랜덤으로 생성할 기둥의 y최대값
    GameObject[] columns;   // 미리 만든 기둥들을 보관할 배열
    int currentColumn = 0;  // 현재 생성된 기둥의 인덱스


	// Use this for initialization
	void Start () 
    {
	    // 기둥을 미리 5개 생성한다.
        // 1. 배열을 할당해야한다.
        columns = new GameObject[columnPoolSize];
        // 2. 프리팹을 이용해서 5개를 만든다.
        for(int i = 0; i < columns.Length; ++i)
        {
            // 프리팹을 복사해서 기둥을 생성한뒤, 배열에 보관 !
            columns[i] = (GameObject)Instantiate(columnPrefab);
            // Instantiate(GameObject); 객체를 생성해 주는 함수

            // 유저가 볼 수 없는 위치에 배치
            columns[i].transform.position = new Vector3(100, 100, 100);
        }

        StartCoroutine("SpawnLoop");
        // 코루틴 함수 시작 !
        // 코루틴 함수 : 유저가 설정한 시간에 따라서 그 시간마다 호출이 가능한 함수
	}

    IEnumerator SpawnLoop()
    {
        while(true)
        {
            // 스포너 원래 위치값 저장
            Vector3 pos = transform.position;

            // y값을 랜덤으로 변경
            pos.y = Random.Range(columnMin, columnMax);

            // 변경된 위치를 미리 생성해놓은 위치로 변경
            columns[currentColumn].transform.position = pos;

            // 배열의 크기보다 커지면 0으로 변경
            if (++currentColumn >= columnPoolSize)
                currentColumn = 0;

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
