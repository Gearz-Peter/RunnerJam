using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShankItemActive : MonoBehaviour
{

    ObjectPooler objectpooler;
    Transform ShootPoint;
    [SerializeField] float Delay;
    float delayR;

    private void Start()
    {
        ShootPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>().ShootPoint;
        objectpooler = ObjectPooler.Instance;
       
    }



    public void Add()
    {
        Delay /= 1.5f;
    }

    private void Update()
    {
       if(delayR <= 0 && Input.GetKey(KeyCode.Space) )
        {
            delayR = Delay;
            StartCoroutine(Shooting());
        }
       else
        {
            delayR -= Time.deltaTime;
        }



    }

    IEnumerator Shooting()
    {
        for(int i=0;i<5;i++)
        {
            yield return null;
            objectpooler.SpawnFromPool("SpikeBullet", ShootPoint.position, Quaternion.identity);
        }
    }
}
