using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class windfly : MonoBehaviour
{
    public Rigidbody2D rgbody;
    public float lastwindowtime = 0;
    public float firstframe = 0;
    public float deltatime = 0;
    public float forceup = 0;
    public float force = 0;
    public bool flipped = false;
    bool count = false;
    void Start()
    {
        if (gameObject.transform.position.x > 0)
        {
            flipped = true;
            gameObject.transform.Rotate(0, 180, 0);
        }

        else
            flipped = false;
        StartCoroutine(Wind());
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!flipped)
        {
            forceup = Mathf.Abs(Mathf.Sin(Time.time));
            force = Mathf.Abs(Mathf.Sin(Time.time));
        }
        else
        {
            forceup = Mathf.Abs(Mathf.Sin(Time.time));
            force = -Mathf.Abs(Mathf.Sin(Time.time));
        }
    }
    IEnumerator Wind()
    {
        while (this.transform.position.x < 132)
        {
            Vector3 up = new Vector3(force, forceup, 0);
            rgbody.velocity = up * 20;
            yield return new WaitForSeconds(Random.Range(1f, 2.5f));
        }

    }

}
