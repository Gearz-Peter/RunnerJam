using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{



    ObjectPooler objectpooler;
    [SerializeField] Transform ShootPoint;
    [Header("Stats")]
    [SerializeField] List<string> CurrentBulletType;
    [SerializeField] float ShootDelay;
    private float ShootDelayRefresh;
    [SerializeField] float SmallBulletDelay, TripleBulletDelay;
    float SmallBulletDelayR, TripleBulletDelayR;


    

    public void AddNewBullet(string bullettype)
    {
        
        switch(bullettype)
        {
            case "SmallBullet":
                SmallBulletDelay /= 1.5f;
                break;
            case "TripleBullet":
                CurrentBulletType.Add("TripleBullet");
                break;
        }
    }
    
    private void Start()
    {
        objectpooler = ObjectPooler.Instance;
        CurrentBulletType.Add("SmallBullet");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            AddNewBullet ("SmallBullet");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddNewBullet("TripleBullet");
        }

        if (Input.GetKey(KeyCode.Space) )
        {
            

            int TripleAmout=0;
            foreach(string BulletT in CurrentBulletType)
            {

                switch (BulletT)
                {
                    case "SmallBullet":
                        if(SmallBulletDelayR <= 0)
                        {
                            objectpooler.SpawnFromPool(BulletT, ShootPoint.position, Quaternion.identity);
                            SmallBulletDelayR = SmallBulletDelay;
                        }
                        break;
                    case "TripleBullet":
                        if(TripleBulletDelayR <=0)
                        {
                            TripleAmout++;
                            objectpooler.SpawnFromPool(BulletT, ShootPoint.position, Quaternion.Euler(0, 10 * TripleAmout, 0));
                            objectpooler.SpawnFromPool(BulletT, ShootPoint.position, Quaternion.identity);
                            objectpooler.SpawnFromPool(BulletT, ShootPoint.position, Quaternion.Euler(0, -10 * TripleAmout, 0));
                        } 
                        break;
                }
            }
           if(TripleAmout > 0)
            {
                TripleBulletDelayR = TripleBulletDelay;
            }
            
        }


        if(SmallBulletDelayR >= 0)
        {
            SmallBulletDelayR -= Time.deltaTime;
        }
        if(TripleBulletDelayR >= 0)
        {
            TripleBulletDelayR -= Time.deltaTime;
        }

     
        
    }
}
