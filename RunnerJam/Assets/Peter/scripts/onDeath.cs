using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onDeath : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private float startHealth;
    private float health;
    private bool dead;

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
            if (Random.Range(0f, 1f) > .49 && !dead)
            {
                Instantiate(item, this.gameObject.transform.position, new Quaternion(0, 0, 0, 1));
                dead = true;
            }

            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -5, 0);
        }

        if (this.gameObject.transform.position.y < -1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            health -= 1;
            //health -= collision.gameObject.GetComponent<damage>().damage;
            Destroy(other.gameObject);
        }
    }
}
