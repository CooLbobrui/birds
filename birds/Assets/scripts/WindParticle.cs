using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindParticle : MonoBehaviour
{
    public Transform pos_part;
    public float windpower;
    public GameObject controller;
    public gameController_sc script;
    public Rigidbody2D rgbody;
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("controller");
        script = controller.GetComponent<gameController_sc>();
        rgbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        windpower = script.windpower;
        pos_part = gameObject.transform;
        rgbody.velocity = 10 * FunctionWind() * windpower;
    }
    Vector3 FunctionWind()
    {
        return Vector3.right;
    }
}
