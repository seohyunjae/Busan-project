using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform[] paths;       // 이동 경로의 목표 지점들을 저장하는 배열
    public GameObject fireworks;   // 이동시킬 대상인 파이어워크(또는 다른 게임 오브젝트)
    public int i = 0;              // 현재 이동 중인 목표 지점의 인덱스
    public float speed = 5f;       // 이동 속도

    private void Start()
    {
        // 시작할 때 파이어워크의 위치를 첫 번째 목표 지점의 위치로 설정
        fireworks.transform.position = paths[0].transform.position;
    }

    private void Update()
    {
        // 파이어워크를 목표 지점으로 일정한 속도로 이동시킴
        fireworks.transform.position = Vector3.MoveTowards(fireworks.transform.position, paths[i].transform.position, speed * Time.deltaTime);

        // 현재 위치가 목표 지점에 도달하면 다음 인덱스로 이동
        if (fireworks.transform.position == paths[i].transform.position)
        {
            i++;
        }

        // 모든 목표 지점을 이동했다면 인덱스를 다시 0으로 초기화
        if (i >= paths.Length)
        {
            i = 0;
        }
    }
}