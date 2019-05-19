using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_floor : MonoBehaviour
{
    public Object parent = null;
    public Vector3 spawnPoint;
    public int floorcounts = 0;
    void Start()
    {
        for (int i = 0; i < floorcounts; i++)
        {
            Instantiate(parent,spawnPoint, Quaternion.identity);
            spawnPoint = new Vector3(spawnPoint.x - 25f, spawnPoint.y, spawnPoint.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
