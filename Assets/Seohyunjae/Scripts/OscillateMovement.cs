using UnityEngine;

public class OscillateMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // �̵� �ӵ�
    public float moveDistance = 5f; // �̵� �Ÿ�
    public float oscillationTime = 2f; // �պ� �ð�

    private float originalX; // �ʱ� X ��ġ
    private float targetX; // ��ǥ X ��ġ
    private float elapsedTime; // ��� �ð�

    private void Start()
    {
        originalX = transform.position.x;
        targetX = originalX + moveDistance;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        // ��� �ð��� ���� �պ� ��ġ ���
        float t = Mathf.PingPong(elapsedTime / oscillationTime, 1f);

        // �̵��� ��ǥ ��ġ ���
        float targetPosX = Mathf.Lerp(originalX, targetX, t);

        // ���� ��ġ���� ��ǥ ��ġ�� ���ϴ� ���� ���� ���
        Vector3 direction = new Vector3(targetPosX - transform.position.x, 0f, 0f).normalized;

        // �̵� ���� ���
        Vector3 movement = direction * moveSpeed * Time.deltaTime;

        // �̵� ����
        transform.position += movement;
    }
}