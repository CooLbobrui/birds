using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    public GameObject egg_prefab;

    public GameObject animHit;
    public GameObject spawner_egg;

    public GameObject egg_anim;
    public GameObject bonus_pill;
    public AudioSource audiohit;
    void Start()
    {
        StartCoroutine(SpawnEgg());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnEgg()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, 20));
            GameObject tmp = Instantiate(egg_anim, spawner_egg.transform.position, Quaternion.identity);
            Destroy(tmp, 0.3f);
            Instantiate(egg_prefab, spawner_egg.transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bird")
        {
            GameObject tmp = Instantiate(animHit, collision.gameObject.transform.position, Quaternion.identity);
            audiohit.Play();
            GameObject.FindGameObjectWithTag("controller").GetComponent<gameController_sc>().SpawnBonus(collision.transform.position);
            Destroy(tmp, 0.4f);
            Destroy(gameObject, 0.5f);

        }
        if (collision.gameObject.tag == "bound")
        {
            GameObject tmp = Instantiate(animHit, collision.gameObject.transform.position, Quaternion.identity);
            audiohit.Play();
            Destroy(tmp, 0.4f);
            Destroy(gameObject, 0.5f);
        }
    }
}
    
