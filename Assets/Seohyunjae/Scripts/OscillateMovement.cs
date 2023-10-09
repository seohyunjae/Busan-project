using UnityEngine;

public class OscillateMovement : MonoBehaviour
{
    public float moveSpeed = 2f;       // 이동 속도
    public float moveDistance = 5f;    // 이동 거리
    public float oscillationTime = 2f; // 왕복 시간

    private float originalX;           // 초기 X 위치
    private float targetX;             // 목표 X 위치
    private float elapsedTime;          // 경과 시간

    private void Start()
    {
        originalX = transform.position.x;         // 시작 시의 오브젝트의 X 위치를 저장
        targetX = originalX + moveDistance;      // 목표 X 위치를 초기 X 위치와 이동 거리를 더한 값으로 설정
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;            // 경과 시간 업데이트

        // 경과 시간에 따라 왕복 위치 계산 (0에서 1 사이의 값을 주기적으로 반복)
        float t = Mathf.PingPong(elapsedTime / oscillationTime, 1f);

        // 이동할 목표 위치 계산 (initial X 위치에서 목표 X 위치 사이를 왕복)
        float targetPosX = Mathf.Lerp(originalX, targetX, t);

        // 현재 위치에서 목표 위치로 향하는 방향 벡터 계산
        Vector3 direction = new Vector3(targetPosX - transform.position.x, 0f, 0f).normalized;

        // 이동 벡터 계산
        Vector3 movement = direction * moveSpeed * Time.deltaTime;

        // 이동 적용
        transform.position += movement;           // 현재 위치에 이동 벡터를 더하여 이동
    }
}


