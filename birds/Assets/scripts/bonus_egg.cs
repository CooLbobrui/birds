using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus_egg : MonoBehaviour
{
    public CapsuleCollider2D coll;
    public Rigidbody2D rgbd;
    public Vector2 velocity;
    private GameObject controller;

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.velocity = new Vector3(10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bird")
        {
            Debug.Log("bird");
        }
        if (collision.gameObject.tag == "player")
        {
            // GameObject tmp = Instantiate(pickupanim, collision.transform.position, Quaternion.identity);
            // Destroy(tmp,0.5f);
            controller = GameObject.FindGameObjectWithTag("controller");
            controller.GetComponent<gameController_sc>().AddScore();
            Destroy(gameObject);
            //StartCoroutine(TouchAnim());            
        }
        if (collision.gameObject.tag == "floor")
        {
            controller = GameObject.FindGameObjectWithTag("controller");
            if (controller.GetComponent<gameController_sc>().bonustime > 0)
            {
                rgbd.velocity = Vector3.up * 100;
            }
            Debug.Log("floor");
        }

    }
}
