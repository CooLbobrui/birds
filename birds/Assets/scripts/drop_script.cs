using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_script : MonoBehaviour
{
    private Rigidbody2D rgbd;
    void Start()
    {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(gameObject);
        
    }
}
