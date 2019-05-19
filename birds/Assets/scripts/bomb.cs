using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject bombanim;
    public GameObject controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "bird")
        {
            Instantiate(bombanim, gameObject.transform.position, Quaternion.identity);
           // GameObject contrl;
           // contrl = GameObject.FindGameObjectWithTag("controller");
            //contrl.GetComponent<gameController_sc>().ToRepair(collision.gameObject.transform.position);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "player")
        {
            Destroy(gameObject);
            Instantiate(bombanim, gameObject.transform.position, Quaternion.identity);
            controller = GameObject.FindGameObjectWithTag("controller");
            controller.GetComponent<gameController_sc>().LoseLife();
        }
    }
}
