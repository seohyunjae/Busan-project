using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    // 생성할 오브젝트의 프리팹
    public GameObject objectPrefab;
    public GameObject objectPrefab2;
    public GameObject objectPrefab3;
    public GameObject objectPrefab4;
    public GameObject Lastshot;
    public GameObject Set1;
    public GameObject Set2;
    public GameObject[] Set3;

    // 생성할 오브젝트의 수
    public int numberOfObjects = 15;

    // 생성할 영역의 크기
    public Vector3 spawnArea = new Vector3(10f, 0f, 10f);

    // 오브젝트들 사이의 간격
    public float spacing = 75f;

    // 오브젝트의 높이 오프셋
    public float heightOffset = 100f;
    public float heightOffset2 = 150f;
    public float heightOffset3 = -30f;
    public float heightOffset4 = 300f;

    Animator ani;
    public GameObject[] zone;

    private void Start()
    {
        // Animator 컴포넌트 가져오기
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        // X 키를 누르면 애니메이션 실행
        if (Input.GetKeyDown(KeyCode.X))
        {
            start_fire_ani();
        }
        // V 키를 누르면 마지막 오브젝트 발사
        if (Input.GetKeyDown(KeyCode.V))
        {
            last_shot();
        }
    }

    // 로켓1 쏘기
    public void rocket1_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // 랜덤한 위치에 오브젝트 생성
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // 오브젝트 생성 및 부모 설정
            GameObject newObject = Instantiate(objectPrefab, randomPosition, Quaternion.identity);
            newObject.transform.SetParent(this.transform.GetChild(1));
            newObject.transform.position = this.transform.GetChild(1).transform.position;
        }
    }

    // 로켓2 쏘기
    public void rocket2_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // 랜덤한 위치에 오브젝트 생성
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset2,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // 오브젝트 생성 및 부모 설정
            GameObject newObject = Instantiate(objectPrefab2, randomPosition, Quaternion.identity);
            newObject.transform.SetParent(this.transform.GetChild(2));
            newObject.transform.position = this.transform.GetChild(2).transform.position;
        }
    }

    // 로켓3 쏘기
    public void rocket3_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // 랜덤한 위치에 오브젝트 생성
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset3,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // 오브젝트 생성 및 부모 설정
            GameObject newObject = Instantiate(objectPrefab3, randomPosition, Quaternion.identity);
            newObject.transform.SetParent(this.transform.GetChild(3));
            newObject.transform.position = this.transform.GetChild(3).transform.position;
        }
    }

    // 로켓4 쏘기
    public void rocket4_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // 랜덤한 위치에 오브젝트 생성
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset4,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // 오브젝트 생성 및 부모 설정
            GameObject newObject = Instantiate(objectPrefab4, randomPosition, Quaternion.identity);
            newObject.transform.SetParent(this.transform.GetChild(4));
            newObject.transform.position = this.transform.GetChild(4).transform.position;
        }
    }

    // 마지막 오브젝트 발사
    public void last_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // 랜덤한 위치에 오브젝트 생성
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset4,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // 오브젝트 생성
            GameObject newObject = Instantiate(Lastshot, randomPosition, Quaternion.identity);
        }
    }

    // Set1 파티클 재생
    public void Set1_shot()
    {
        Set1.GetComponent<ParticleSystem>().Play();
    }

    // Set2 파티클 재생
    public void Set2_shot()
    {
        Set2.GetComponent<ParticleSystem>().Play();
    }

    // Set3 파티클 재생 및 지연 후 소리 재생
    public void Set3_shot()
    {
        foreach (GameObject i in Set3)
        {
            i.GetComponent<ParticleSystem>().Play();
        }
        Invoke("Set3sound", 2f);
    }

    // Set3 파티클 소리 재생
    void Set3sound()
    {
        this.transform.GetChild(0).GetComponent<AudioSource>().Play();
    }

    // 애니메이션 실행
    public void start_fire_ani()
    {
        ani.SetTrigger("test_shot");
    }
}