using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public CapsuleCollider2D coll;
    public GameObject pickupanim;
    private GameObject controller;

    public GameObject bonus_egg1;
    public GameObject bonus_egg2;

    public Rigidbody2D rgbd;
    public Vector2 velocity;
    public bool spawned = false;
    public bool wasgrounded = false;
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = rgbd.velocity;
        if (velocity.y < 5)
        {
            controller = GameObject.FindGameObjectWithTag("controller");
            if (controller.GetComponent<gameController_sc>().bonustime > 0)
            {
                if (!spawned && wasgrounded)
                {

                    Vector3 pos1 = new Vector3(gameObject.transform.position.x + 3, gameObject.transform.position.y,-4);
                    Vector3 pos2 = new Vector3(gameObject.transform.position.x - 3, gameObject.transform.position.y,-4);

                    Instantiate(bonus_egg1, pos1, Quaternion.identity);
                    Instantiate(bonus_egg2, pos2, Quaternion.identity);
                    spawned = true;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bird")
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
            wasgrounded = true;
            controller = GameObject.FindGameObjectWithTag("controller");
            if(controller.GetComponent<gameController_sc>().bonustime > 0)
            {
                rgbd.velocity = Vector3.up * 100;
            }
            Debug.Log("floor");
        }

    }
   
    IEnumerator TouchAnim(Vector3 parent)
    {


        yield return new WaitForSeconds(1);
        
    }
                
}
