using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    private Rigidbody2D rgbd;
    private Vector3 FlyForce = new Vector3 (10,0,0);
    public GameObject posdrop1;
    public GameObject posdrop2;
    public GameObject posdrop3;
    public GameObject[] drops;
    public GameObject controller;
    public int tmp;
    void Start()
    {

        rgbd = gameObject.GetComponent<Rigidbody2D>();
        controller = GameObject.FindGameObjectWithTag("controller");
        StartCoroutine(DoFly());
        StartCoroutine(StartRain());
    }

    // Update is called once per frame
    void Update()
    {
        //var wave = Mathf.Sin(Time.timeSinceLevelLoad) * 0.5f + 0.5f;
       
        if ( (transform.position.x > 125) || (transform.position.x < -125))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator DoFly()
    {
        yield return new WaitForSeconds(1f);
        if(controller.GetComponent<gameController_sc>().windpower > 0)
            rgbd.velocity = FlyForce;
        else
            rgbd.velocity = -FlyForce;
    }
    IEnumerator StartRain()
    {
        while (controller.GetComponent<gameController_sc>().raining)
        {
            tmp = Random.Range(0, 3);
            if (tmp == 0)
                Instantiate(drops[Random.Range(0, 3)], posdrop1.transform.position, Quaternion.identity);
            if (tmp == 1)
                Instantiate(drops[Random.Range(0, 3)], posdrop2.transform.position, Quaternion.identity);
            if (tmp == 2)
                Instantiate(drops[Random.Range(0, 3)], posdrop3.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
