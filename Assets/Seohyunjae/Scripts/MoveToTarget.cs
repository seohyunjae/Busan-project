using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform[] paths;       // �̵� ����� ��ǥ �������� �����ϴ� �迭
    public GameObject fireworks;   // �̵���ų ����� ���̾��ũ(�Ǵ� �ٸ� ���� ������Ʈ)
    public int i = 0;              // ���� �̵� ���� ��ǥ ������ �ε���
    public float speed = 5f;       // �̵� �ӵ�

    private void Start()
    {
        // ������ �� ���̾��ũ�� ��ġ�� ù ��° ��ǥ ������ ��ġ�� ����
        fireworks.transform.position = paths[0].transform.position;
    }

    private void Update()
    {
        // ���̾��ũ�� ��ǥ �������� ������ �ӵ��� �̵���Ŵ
        fireworks.transform.position = Vector3.MoveTowards(fireworks.transform.position, paths[i].transform.position, speed * Time.deltaTime);

        // ���� ��ġ�� ��ǥ ������ �����ϸ� ���� �ε����� �̵�
        if (fireworks.transform.position == paths[i].transform.position)
        {
            i++;
        }

        // ��� ��ǥ ������ �̵��ߴٸ� �ε����� �ٽ� 0���� �ʱ�ȭ
        if (i >= paths.Length)
        {
            i = 0;
        }
    }
}