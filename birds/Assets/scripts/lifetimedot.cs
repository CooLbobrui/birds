using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifetimedot : MonoBehaviour
{
    public float lifetime;
    public float time;
    void Start()
    {
        //lifetime = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}
