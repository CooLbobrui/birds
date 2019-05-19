using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animdot : MonoBehaviour
{
    public GameObject dot;
    void Start()
    {
        StartCoroutine(SpawnDot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnDot()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, 0.001f));
            Instantiate(dot, gameObject.transform.position + new Vector3 (Random.Range(0,1f),Random.Range(0,1f)), Quaternion.identity);
        }
    }
}
