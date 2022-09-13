using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriBullet : MonoBehaviour, IPoolerObject
{
    [SerializeField] float LifeTime;
    [SerializeField] float BulletSpeed;


    public void OnObjectSpawn()
    {
       
        //GetComponent<Rigidbody>().velocity = 
        LifeTime = 5;

    }
    private void Update()
    {

        if (LifeTime > 0)
        {
            transform.position += Time.deltaTime * transform.forward * BulletSpeed;
            LifeTime -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
