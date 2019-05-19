using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_character : MonoBehaviour
{
    public Rigidbody2D rgbody = null;
    private bool flipped = true;
    private bool grounded;
    public GameObject animEgg;
    public GameObject point_circle;
    // Start is called before the first frame update
    public Vector3 point;
    public float D;
    void Start()
    {
        grounded = false;
    }

    // Update 
    void Update()
    {
        
        onCircleCoord(Random.Range(-50f,50f));
       // D = GetPoint(50, gameObject.transform.position.x, gameObject.transform.position.y, 1,true);
        //tmp = GetPoint(50, gameObject.transform.position.x, gameObject.transform.position.y, 1);
        //Instantiate(point_circle, tmp, Quaternion.identity);
    }
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.Joystick1Button0))
            Debug.Log("1");
        if (Input.GetKey(KeyCode.Joystick1Button1))
            Debug.Log("2");
        if (Input.GetKey(KeyCode.Joystick1Button2))
            Debug.Log("3");
        if (Input.GetKey(KeyCode.Joystick1Button3))
            Debug.Log("4");
        if (Input.GetKey(KeyCode.Joystick1Button4))
            Debug.Log("5");
        if (Input.GetKey(KeyCode.Joystick1Button5))
            Debug.Log("6");
        if (Input.GetKey(KeyCode.Joystick1Button6))
            Debug.Log("7");
        if (Input.GetKey(KeyCode.Joystick1Button7))
            Debug.Log("8");
        if (Input.GetKey(KeyCode.Joystick1Button8))
            Debug.Log("9");
        if (Input.GetKey(KeyCode.Joystick1Button9))
            Debug.Log("10");
        if (Input.GetKey(KeyCode.Joystick1Button10))
            Debug.Log("11");
        if (Input.GetKey(KeyCode.Joystick1Button11))
            Debug.Log("12");
        if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0 )
        {
            if (!flipped)
            {
                transform.Rotate(0, 180, 0);
                flipped = true;
                rgbody.velocity = new Vector3(-40, rgbody.velocity.y);
            }
            else
            {

                rgbody.velocity = rgbody.velocity = new Vector3(-40, rgbody.velocity.y);
            }

        }
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0 )
        {
            if (flipped)
            {
                flipped = false;
                transform.Rotate(0, 180, 0);
                rgbody.velocity = rgbody.velocity = new Vector3(40, rgbody.velocity.y);
            }
            else
                rgbody.velocity = rgbody.velocity = new Vector3(40, rgbody.velocity.y);

        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button0))
        {
            if (grounded)
            {
                grounded = false;
                rgbody.velocity = new Vector3(rgbody.velocity.x, 80);
            }
            if (rgbody.velocity.y >= 1)
                grounded = false;
            if (rgbody.velocity.y >= -1)
                grounded = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "egg")
        {
            //float timeleft = 1f;
            GameObject tmp = Instantiate(animEgg, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(tmp, 0.4f);
            Debug.Log(Time.deltaTime);
        }
        if (collision.gameObject.tag == "floor")
        {
            if (!grounded)
                grounded = true;
        }
    }
    public void ForcedMove(Vector3 tmp)
    {
        rgbody.velocity = tmp * 50;
    }
    public void onCircleCoord(float x)
    {
        float y = Mathf.Sqrt(2500 - Mathf.Pow(x, 2));
        Vector3 tmp = new Vector3(x, -4);
        Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere), tmp, Quaternion.identity);
        //point_circle.transform.position = tmp;
        y = -Mathf.Sqrt(2500 - Mathf.Pow(x, 2));
        tmp = new Vector3(x, y, -4);
        Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere), tmp, Quaternion.identity);

    }



    public Vector3 GetPoint(float radius, float a0,float b0, float x)
    {
        float y1=0, y2=0;
        float discr = 0;
        discr = -4 * Mathf.Pow(a0, 2) + (8 * x * -2 * a0) - 4 * Mathf.Pow(a0, 2) + 4 * radius;
        if (discr > 0)
        {
            y1 = -(b0 + Mathf.Sqrt(discr)) / ( 2 * a0);
            y2 = -(b0 - Mathf.Sqrt(discr)) / ( 2 * a0);
        }
        point.x = x;
        point.y = y1;
        point.z = -4;

        return point;
    }
    public float GetPoint(float radius, float a0, float b0, float x, bool dscr_search)
    {
        float discr = 0;
        discr = -4 * Mathf.Pow(a0, 2) + (8 * x * -2 * a0 ) - 4 * Mathf.Pow(a0, 2) + 4 * radius;
        return discr;
    }
    public float Invert(float b)
    {
        return b = b - 2 * b;
    }
}
