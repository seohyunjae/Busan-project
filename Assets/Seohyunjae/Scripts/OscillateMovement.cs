using UnityEngine;

public class OscillateMovement : MonoBehaviour
{
    public float moveSpeed = 2f;       // �̵� �ӵ�
    public float moveDistance = 5f;    // �̵� �Ÿ�
    public float oscillationTime = 2f; // �պ� �ð�

    private float originalX;           // �ʱ� X ��ġ
    private float targetX;             // ��ǥ X ��ġ
    private float elapsedTime;          // ��� �ð�

    private void Start()
    {
        originalX = transform.position.x;         // ���� ���� ������Ʈ�� X ��ġ�� ����
        targetX = originalX + moveDistance;      // ��ǥ X ��ġ�� �ʱ� X ��ġ�� �̵� �Ÿ��� ���� ������ ����
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;            // ��� �ð� ������Ʈ

        // ��� �ð��� ���� �պ� ��ġ ��� (0���� 1 ������ ���� �ֱ������� �ݺ�)
        float t = Mathf.PingPong(elapsedTime / oscillationTime, 1f);

        // �̵��� ��ǥ ��ġ ��� (initial X ��ġ���� ��ǥ X ��ġ ���̸� �պ�)
        float targetPosX = Mathf.Lerp(originalX, targetX, t);

        // ���� ��ġ���� ��ǥ ��ġ�� ���ϴ� ���� ���� ���
        Vector3 direction = new Vector3(targetPosX - transform.position.x, 0f, 0f).normalized;

        // �̵� ���� ���
        Vector3 movement = direction * moveSpeed * Time.deltaTime;

        // �̵� ����
        transform.position += movement;           // ���� ��ġ�� �̵� ���͸� ���Ͽ� �̵�
    }
}


