using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private GameObject gamecontroller;
    private gameController_sc script;
    void Start()
    {
        gamecontroller = GameObject.FindGameObjectWithTag("controller");
        script = gamecontroller.GetComponent<gameController_sc>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0.0001f,0)* script.windpower,ForceMode2D.Impulse);
    }
}
