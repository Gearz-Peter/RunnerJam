using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onDeath : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private float startHealth;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        startHealth = GameObject.FindWithTag("DontDestroy").GetComponent<DifficultyScaling>().difficulty * 100;
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l") || health <= 0)
        {
            if (Random.Range(0f, 1f) > .7)
            {
                Instantiate(item, this.gameObject.transform.position, new Quaternion(0, 0, 0, 1));
            }
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "playerBullet")
        {
            //health -= collision.gameObject.GetComponent<damage>().damage;
        }
    }
}
