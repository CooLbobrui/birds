using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController_sc : MonoBehaviour
{
    public GameObject bird_prefab;
    public GameObject pill_prefab;
    public GameObject bomb_prefab;
    public GameObject floor_prefab;
    public GameObject floor_egde_prefab;
    public GameObject heart_prefab;

    public GameObject bomb_anim;

    public bool flipped = true;
    public bool raining = true;

    public GameObject spawner_bird;
    public GameObject spawner_touch;

    public GameObject spawner_cloud1;
    public GameObject spawner_cloud2;

    public GameObject[] clouds;

    public GameObject hit_birds;

    public float windpower;

    public GameObject spawner_point1;
    public GameObject spawner_point2;
    public GameObject spawner_point3;
    public GameObject spawner_point4;

    public GameObject heart_pos1;
    public GameObject heart_pos2;

    public bool activebonus;
    public float bonustime;
    //public int eggcount;
    public int egginc;
    public float checker = 2;
    //public GameObject[] listegg;
    public Text eggtext;
    public Text bonustext;
    public GameObject[] listrepair;
    public int size;
    public Vector3[] coordrepair;
    public GameObject[] hearts;
    public int life;


    void Start()
    {
        size = 0;
        life = 3;
        activebonus = false;
        bonustime = 0f;
        windpower = 2f;
        StartCoroutine(SpawnBird1());
        egginc = 0;
        StartCoroutine(SpawnClouds());
        StartCoroutine(Weather());
        StartCoroutine(SpawnBombs());
        listrepair = GameObject.FindGameObjectsWithTag("floor");
        hearts = GameObject.FindGameObjectsWithTag("heart");
        coordrepair = new Vector3[listrepair.Length];
        ToRepair();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Repair();
        GameObject[] list = GameObject.FindGameObjectsWithTag("bonus");
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        // listegg = GameObject.FindGameObjectsWithTag("egg");
        // eggcount = listegg.Length;

        eggtext.text = ": " + egginc.ToString();

        if (bonustime >= 0)
        {
            bonustime = bonustime - Time.deltaTime;
            bonustext.text = ": " + bonustime.ToString();
        }
        else
            bonustext.text = ": 0";
    }
    IEnumerator SpawnBird1()
    {
        while (true)
        {
            int point = Random.Range(1, 4);
            yield return new WaitForSeconds(Random.Range(5, 10));
            if (point == 1)
            {
                flipped = true;
                StartCoroutine(SpawnAnim(spawner_point3.transform.position));
                Instantiate(bird_prefab, spawner_point3.transform.position, Quaternion.identity);
            }
            if (point == 2)
            {
                flipped = true;
                StartCoroutine(SpawnAnim(spawner_point4.transform.position));
                Instantiate(bird_prefab, spawner_point4.transform.position, Quaternion.identity);
            }
            if (point == 3)
            {
                flipped = false;
                StartCoroutine(SpawnAnim(spawner_point2.transform.position));
                Instantiate(bird_prefab, spawner_point2.transform.position, Quaternion.identity);
            }
            if (point == 4)
            {
                flipped = false;
                StartCoroutine(SpawnAnim(spawner_point1.transform.position));
                Instantiate(bird_prefab, spawner_point1.transform.position, Quaternion.identity);
            }
        }
    }
    IEnumerator SpawnAnim(Vector3 parent)
    {

        GameObject tmp = Instantiate(spawner_bird, parent, Quaternion.identity);
        yield return new WaitForSeconds(0.7f);
        Destroy(tmp);
    }
    public void AddScore()
    {
        egginc++;
    }
    public void SpawnBonus(Vector3 coord)
    {
        checker++;
        if (checker % 2 == 0f)
        {

            GameObject tmp = Instantiate(pill_prefab, coord, Quaternion.identity);
        }
    }
    public void AddBonusTime()
    {
        bonustime = bonustime + 30f;
    }
    IEnumerator SpawnClouds()
    {
        while (true)
        {
            if (windpower > 0)
            {
                Instantiate(clouds[Random.Range(0, 2)], spawner_cloud1.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(1f, 5f));
            }
            else
            {
                Instantiate(clouds[Random.Range(0, 2)], spawner_cloud2.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(1f, 5f));
            }

        }
    }
    public void ChangeWind()
    {
        windpower = Random.Range(-2.0f, 2.0f);
    }
    IEnumerator Weather()
    {
        while (raining)
        {
            yield return new WaitForSeconds(Random.Range(20, 40));
            ChangeWind();
        }
    }
    IEnumerator SpawnBombs()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(20, 40));
            int tmp = Random.Range(-115, 115);
            Instantiate(bomb_anim, new Vector3(tmp, spawner_point2.transform.position.y), Quaternion.identity);
            Instantiate(bomb_prefab, new Vector3(tmp, spawner_point2.transform.position.y), Quaternion.identity);
        }
    }
    public void ToRepair ()
    {
        size = listrepair.Length;
       for (int i=0; i < size; i++)
        {
            if (listrepair[i] != null);
            coordrepair[i] = listrepair[i].gameObject.transform.position;
        }
       // size++;
    }
    public void Repair()
    {
        for (int i=0; i < size; i++)
        {
            if (listrepair[i] == null)
            {
                Vector3 tmp = new Vector3(coordrepair[i].x, coordrepair[i].y - 100, coordrepair[i].z);
                if (Random.Range(0, 2) == 1)
                {
                    listrepair[i] = Instantiate(floor_prefab, tmp, Quaternion.identity);
                    StartCoroutine(RepairPlatform(coordrepair[i], listrepair[i]));
                }
                else
                {
                    listrepair[i] = Instantiate(floor_egde_prefab, tmp, Quaternion.identity);
                    StartCoroutine(RepairPlatform(coordrepair[i], listrepair[i], true));
                }
                
            }

        }
    }
    IEnumerator RepairPlatform (Vector3 pos, GameObject go)
    {
       
        while (pos.y - go.transform.position.y > 1)
        {
            go.GetComponent<BoxCollider2D>().isTrigger = enabled;
            go.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            go.GetComponent<Rigidbody2D>().velocity = Vector3.up * 10;
            yield return new WaitForSeconds(1f);
        }
        go.GetComponent<BoxCollider2D>().isTrigger = false;
        go.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

    }
    IEnumerator RepairPlatform(Vector3 pos, GameObject go, bool egdes)
    {

        while (pos.y - go.transform.position.y > 1)
        {
            for (int i = 0; i< 5; i++)
            {
                go.GetComponent<floor>().edges[i].GetComponent<BoxCollider2D>().isTrigger = enabled;
                go.GetComponent<floor>().edges[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                go.GetComponent<floor>().edges[i].GetComponent<Rigidbody2D>().velocity = Vector3.up * 10;
            }
            go.GetComponent<BoxCollider2D>().isTrigger = enabled;
            go.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            go.GetComponent<Rigidbody2D>().velocity = Vector3.up * 10;
            yield return new WaitForSeconds(1f);
        }
        for (int i = 0; i < 5; i++)
        {
            go.GetComponent<floor>().edges[i].GetComponent<BoxCollider2D>().isTrigger = false;
            go.GetComponent<floor>().edges[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
           
        }
        go.GetComponent<BoxCollider2D>().isTrigger = false;
        go.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

    }
    public void LoseLife()
    {
        if (life == 1)
        {
            life--;
            SpawnAnim(hearts[life].gameObject.transform.position);
            Destroy(hearts[life].gameObject);
            GameOver();
        }

        if (life == 2)
        {
            life--;
            SpawnAnim(hearts[life].gameObject.transform.position);
            Destroy(hearts[life].gameObject);
        }
        if (life == 3)
        {
            life--;
            SpawnAnim(hearts[life].gameObject.transform.position);
            Destroy(hearts[life].gameObject);
        }
       
       
    }
    public void GainLife()
    {
        if (life == 1)
        {
            life++;
            Instantiate(heart_prefab, heart_pos1.transform.position, Quaternion.identity);
        }
        if (life == 2)
        {
            life++;
            Instantiate(heart_prefab, heart_pos2.transform.position, Quaternion.identity);
        }
        
    }
    void GameOver()
    {
        SpawnAnim(GameObject.FindGameObjectWithTag("player").transform.position);
        Destroy(GameObject.FindGameObjectWithTag("player"));
    }
}

