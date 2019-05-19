using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    public Vector3 tmp;
    public GameObject[] edges;
    void Start()
    {
        tmp = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        //Vector3 tmp = gameObject.transform.position;
       // GameObject contrl;
        //contrl = GameObject.FindGameObjectWithTag("controller");
        //contrl.GetComponent<gameController_sc>().ToRepair(tmp);
    }
}
