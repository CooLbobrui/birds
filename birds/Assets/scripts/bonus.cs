using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour
{
   // public bool active;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            //active = true;
            GameObject.FindGameObjectWithTag("controller").GetComponent<gameController_sc>().AddBonusTime();
            Destroy(gameObject);
        }
    }
}
