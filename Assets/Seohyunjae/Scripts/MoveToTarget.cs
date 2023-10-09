using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
   
    public Transform[] paths;
    public GameObject fireworks;
    public int i = 0;
    public float speed = 5f; 

    private void Start()
    {
        fireworks.transform.position = paths[0].transform.position;
    }
    private void Update()
    {
        fireworks.transform.position = Vector3.MoveTowards(fireworks.transform.position, paths[i].transform.position, speed * Time.deltaTime);
        if (fireworks.transform.position == paths[i].transform.position)
        {
            i++;
        }

        if (i >= paths.Length)
        {
            i = 0;
        }

    }
    




}
