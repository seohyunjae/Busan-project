using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject objectPrefab; // 생성할 오브젝트의 프리팹
    public GameObject objectPrefab2; // 생성할 오브젝트의 프리팹
    public GameObject objectPrefab3; // 생성할 오브젝트의 프리팹
    public GameObject objectPrefab4; // 생성할 오브젝트의 프리팹
    public GameObject Lastshot; // 생성할 오브젝트의 프리팹
    public GameObject Set1;
    public GameObject Set2;
    public GameObject[] Set3;

    public int numberOfObjects = 15; // 생성할 오브젝트의 수
    public Vector3 spawnArea = new Vector3(10f, 0f, 10f); // 생성할 영역의 크기
    public float spacing = 75f; // 오브젝트들 사이의 간격
    public float heightOffset = 100f; // 오브젝트의 높이 오프셋
    public float heightOffset2 = 150f; // 오브젝트의 높이 오프셋
    public float heightOffset3 = -30f; // 오브젝트의 높이 오프셋
    public float heightOffset4 = 300f; // 오브젝트의 높이 오프셋


    Animator ani;
    public GameObject[] zone;


    private void Start()
    {

        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) {
            start_fire_ani();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            last_shot();
        }

        
    }
    public void rocket1_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {

            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),     heightOffset,     Random.Range(-spawnArea.z / 2, spawnArea.z / 2));

            GameObject newObject = Instantiate(objectPrefab, randomPosition, Quaternion.identity);
            newObject.transform.SetParent(this.transform.GetChild(1));
            newObject.transform.position = this.transform.GetChild(1).transform.position;   
        }
    }
    public void rocket2_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset2,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            GameObject newObject = Instantiate(objectPrefab2, randomPosition, Quaternion.identity);
            newObject.transform.SetParent(this.transform.GetChild(2));
            newObject.transform.position = this.transform.GetChild(2).transform.position;
        }
    }
    public void rocket3_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset3,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            GameObject newObject = Instantiate(objectPrefab3, randomPosition, Quaternion.identity);
            newObject.transform.SetParent(this.transform.GetChild(3));
            newObject.transform.position = this.transform.GetChild(3).transform.position;
        }
    }
    public void rocket4_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset4,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            GameObject newObject = Instantiate(objectPrefab4, randomPosition, Quaternion.identity);
            newObject.transform.SetParent(this.transform.GetChild(4));
            newObject.transform.position = this.transform.GetChild(4).transform.position;
        }
    }

    public void last_shot()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2) + (i * spacing),
                heightOffset4,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            GameObject newObject = Instantiate(Lastshot, randomPosition, Quaternion.identity);
            
        }
    }
    public void Set1_shot()
    {

        Set1.GetComponent<ParticleSystem>().Play();
       

    }
    public void Set2_shot()
    {

        Set2.GetComponent<ParticleSystem>().Play();


    }
    public void Set3_shot()
    {

       
        foreach(GameObject i in Set3)
        {
            i.GetComponent<ParticleSystem>().Play();

        }

        Invoke("Set3sound", 2f);


    }

    void Set3sound()
    {
        this.transform.GetChild(0).GetComponent<AudioSource>().Play();
    }

    public void start_fire_ani()
    {
        ani.SetTrigger("test_shot");
    }
}