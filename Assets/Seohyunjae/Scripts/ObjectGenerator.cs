using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    // ������ ������Ʈ�� ������
    public GameObject objectPrefab;
    public GameObject objectPrefab2;
    public GameObject objectPrefab3;
    public GameObject objectPrefab4;
    public GameObject Lastshot;
    public GameObject Set1;
    public GameObject Set2;
    public GameObject[] Set3;

    // ������ ������Ʈ�� ��
    public int numberOfObjects = 15;

    // ������ ������ ũ��
    public Vector3 spawnArea = new Vector3(10f, 0f, 10f);

    // ������Ʈ�� ������ ����
    public float spacing = 75f;

    // ������Ʈ�� ���� ������
    public float heightOffset = 100f;
    public float heightOffset2 = 150f;
    public float heightOffset3 = -30f;
    public float heightOffset4 = 300f;

    Animator ani;
    public GameObject[] zone;

    private void Start()
    {
        // Animator ������Ʈ ��������
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        // X Ű�� ������ �ִϸ��̼� ����
        if (Input.GetKeyDown(KeyCode.X))
        {
            start_fire_ani();
        }
        // V Ű�� ������ ������ ������Ʈ �߻�
        if (Input.GetKeyDown(KeyCode.V))
        {
            last_shot();
        }
    }

    // ����1 ���
    public void rocket1_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // ������ ��ġ�� ������Ʈ ����
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // ������Ʈ ���� �� �θ� ����
            GameObject newObject = Instantiate(objectPrefab, randomPosition, Quaternion.identity);
            newObject.transform.SetParent(this.transform.GetChild(1));
            newObject.transform.position = this.transform.GetChild(1).transform.position;
        }
    }

    // ����2 ���
    public void rocket2_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // ������ ��ġ�� ������Ʈ ����
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset2,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // ������Ʈ ���� �� �θ� ����
            GameObject newObject = Instantiate(objectPrefab2, randomPosition, Quaternion.identity);
            newObject.transform.SetParent(this.transform.GetChild(2));
            newObject.transform.position = this.transform.GetChild(2).transform.position;
        }
    }

    // ����3 ���
    public void rocket3_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // ������ ��ġ�� ������Ʈ ����
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset3,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // ������Ʈ ���� �� �θ� ����
            GameObject newObject = Instantiate(objectPrefab3, randomPosition, Quaternion.identity);
            newObject.transform.SetParent(this.transform.GetChild(3));
            newObject.transform.position = this.transform.GetChild(3).transform.position;
        }
    }

    // ����4 ���
    public void rocket4_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // ������ ��ġ�� ������Ʈ ����
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset4,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // ������Ʈ ���� �� �θ� ����
            GameObject newObject = Instantiate(objectPrefab4, randomPosition, Quaternion.identity);
            newObject.transform.SetParent(this.transform.GetChild(4));
            newObject.transform.position = this.transform.GetChild(4).transform.position;
        }
    }

    // ������ ������Ʈ �߻�
    public void last_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // ������ ��ġ�� ������Ʈ ����
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset4,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // ������Ʈ ����
            GameObject newObject = Instantiate(Lastshot, randomPosition, Quaternion.identity);
        }
    }

    // Set1 ��ƼŬ ���
    public void Set1_shot()
    {
        Set1.GetComponent<ParticleSystem>().Play();
    }

    // Set2 ��ƼŬ ���
    public void Set2_shot()
    {
        Set2.GetComponent<ParticleSystem>().Play();
    }

    // Set3 ��ƼŬ ��� �� ���� �� �Ҹ� ���
    public void Set3_shot()
    {
        foreach (GameObject i in Set3)
        {
            i.GetComponent<ParticleSystem>().Play();
        }
        Invoke("Set3sound", 2f);
    }

    // Set3 ��ƼŬ �Ҹ� ���
    void Set3sound()
    {
        this.transform.GetChild(0).GetComponent<AudioSource>().Play();
    }

    // �ִϸ��̼� ����
    public void start_fire_ani()
    {
        ani.SetTrigger("test_shot");
    }
}