using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyInitialisation : MonoBehaviour
{
    [SerializeField]private int timer = 0;
    private bool start = true;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-6);
        this.gameObject.transform.position = new Vector3(Random.Range(-9f,9f), this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer < 35)
        {
            timer++;
        }
        else if (start == true)
        {
            start = false;
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        
    }
}
