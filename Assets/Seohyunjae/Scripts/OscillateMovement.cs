using UnityEngine;

public class OscillateMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // 이동 속도
    public float moveDistance = 5f; // 이동 거리
    public float oscillationTime = 2f; // 왕복 시간

    private float originalX; // 초기 X 위치
    private float targetX; // 목표 X 위치
    private float elapsedTime; // 경과 시간

    private void Start()
    {
        originalX = transform.position.x;
        targetX = originalX + moveDistance;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        // 경과 시간에 따라 왕복 위치 계산
        float t = Mathf.PingPong(elapsedTime / oscillationTime, 1f);

        // 이동할 목표 위치 계산
        float targetPosX = Mathf.Lerp(originalX, targetX, t);

        // 현재 위치에서 목표 위치로 향하는 방향 벡터 계산
        Vector3 direction = new Vector3(targetPosX - transform.position.x, 0f, 0f).normalized;

        // 이동 벡터 계산
        Vector3 movement = direction * moveSpeed * Time.deltaTime;

        // 이동 적용
        transform.position += movement;
    }
}