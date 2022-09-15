using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBulletCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Bullet")
        {

            other.gameObject.SetActive(false);
            //Do something more
        }
    }
}
