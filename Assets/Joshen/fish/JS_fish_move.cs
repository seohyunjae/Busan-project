using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

public class JS_fish_move : MonoBehaviour
{
    public float Speed = 50.0f;
    private Transform myTransform = null;
    private Rigidbody rb = null;
    public JS_Fish_game game = null;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.up * Random.Range(-170, 170.0f));
        myTransform = GetComponent<Transform>();
        game = GameObject.FindWithTag("Gamecount").GetComponent<JS_Fish_game>();
        // rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 moveAmount = Speed * Vector3.forward * Time.deltaTime;
         myTransform.Translate(moveAmount);

        if(!game._isgamestart)
        {
            Destroy(this.gameObject);

        }
        // rb.AddForce(Vector3.forward * Speed);   

        // if (myTransform.position.y <= -60.0f)
        //{
        //    myTransform.position = new Vector3(Random.Range(-60.0f, 60.0f), 60.0f, 0.0f);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WaterTank"))
        {
            transform.Rotate(Vector3.up * Random.Range(190.0f, 170.0f));
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
     if(collision.gameObject.CompareTag("WaterTank"))
        {
            transform.Rotate(Vector3.up * 170);
        }
    }
    */

    public void getpoint()
    {
        game.gamescore++;
        Destroy(this.gameObject);
    }
}
