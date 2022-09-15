using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBulletCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet");
            other.gameObject.SetActive(false);
        }
    }
}
