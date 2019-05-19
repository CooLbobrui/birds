using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egde_script : MonoBehaviour
{
    public GameObject controller;
    public Rigidbody2D rgbd;
    public GameObject player;
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("controller");
        player = GameObject.FindGameObjectWithTag("player");
        rgbd = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            controller.GetComponent<gameController_sc>().LoseLife();
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                Vector3 tmp = new Vector3(-1, 1, 0);
                player.GetComponent<main_character>().ForcedMove(tmp);
            }
            if (player.transform.position.x > gameObject.transform.position.x)
            {
                Vector3 tmp = new Vector3(1, 1, 0);
                player.GetComponent<main_character>().ForcedMove(tmp);
            }

        }
    }
}
