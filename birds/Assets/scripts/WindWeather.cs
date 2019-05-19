using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindWeather : MonoBehaviour
{
    public GameObject particle_prefab;
    public int countsParticles;
    public GameObject wind_point;
    void Start()
    {
        StartCoroutine(WindBlow());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    IEnumerator WindBlow()
    {
        while (countsParticles > 0)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(particle_prefab, wind_point.transform.position, Quaternion.identity);
            countsParticles--;
        }
    }

}
