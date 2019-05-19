using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endlife : MonoBehaviour
{
    public float endlifetime = 0.4f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        endlifetime -= Time.deltaTime;
        if (endlifetime < 0)
            Destroy(gameObject);
    }
}
