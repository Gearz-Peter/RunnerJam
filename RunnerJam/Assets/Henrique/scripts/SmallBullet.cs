using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBullet : MonoBehaviour, IPoolerObject
{
    [SerializeField] float LifeTime;
    [SerializeField] float BulletSpeed;
    

    public void OnObjectSpawn()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,BulletSpeed);
        LifeTime = 5;

    }
    private void Update()
    {
      
       if (LifeTime > 0)
        {
           
            LifeTime -= Time.deltaTime;
        }
       else
        {
            gameObject.SetActive(false);
        }
    }
}
