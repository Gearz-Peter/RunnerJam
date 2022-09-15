using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{



    ObjectPooler objectpooler;
    public Transform ShootPoint;
    [Header("Stats")]
    [SerializeField] List<string> CurrentBulletType,CurrentItems;
    [SerializeField] float ShootDelay;
    private float ShootDelayRefresh;
    [SerializeField] float SmallBulletDelay, TripleBulletDelay;
    float SmallBulletDelayR, TripleBulletDelayR;
    [SerializeField] GameObject ItemCanvas,TheCanvas;
    [SerializeField] List<GameObject> ItemsInCanvas;
    [SerializeField] GameObject[] CanvasItems,ItemPickUps;
    [SerializeField] GameObject EmptyItem;

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


    public void AddNewItem(string item)
    {
       for(int i=0;i<CurrentItems.Count;i++)
        {
            if(CurrentItems[i] == item)
            {
                ItemsInCanvas[i].gameObject.SendMessage("Add");
                return;
            }
        }


        switch (item)
        {
            case "Shanky":
                CurrentItems.Add(item);
               GameObject obj = Instantiate(CanvasItems[0], transform.position, Quaternion.identity, ItemCanvas.transform);
                ItemsInCanvas.Add(obj);
                break;
        }
    }

    public void RemoveItem()
    {
        if(CurrentItems.Count == 0)
        {
            //death
            return;
        }
        int randomitem = Random.Range(0, CurrentItems.Count);
        CurrentItems.RemoveAt(randomitem);
        string itemname = ItemsInCanvas[randomitem].gameObject.name;
        int index=0;
        for(int i=0;i<CanvasItems.Length;i++)
        {
            if(CanvasItems[i].gameObject.name == itemname)
            {
                index = i;
                i = CanvasItems.Length;
            }
        }
        int Amout;
        int.TryParse( ItemsInCanvas[randomitem].GetComponentInChildren<Text>().text,out Amout);
        Destroy(ItemsInCanvas[randomitem]);
        ItemsInCanvas.RemoveAt(randomitem);
        for(int a=0;a<Amout;a++)
        {
          GameObject empty=  Instantiate(EmptyItem, transform.position + new Vector3(Random.Range(1, 2), transform.position.y - 1, Random.Range(1, 2)), Quaternion.identity);
           GameObject obj = Instantiate(ItemPickUps[index], empty.transform.position, Quaternion.identity,empty.transform);
           
        }






    }


    //public void 


    private void Start()
    {
        DontDestroyOnLoad(TheCanvas);

        objectpooler = ObjectPooler.Instance;
        CurrentBulletType.Add("SmallBullet");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            RemoveItem();
        }
        if (Input.GetKeyDown(KeyCode.P))
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
                            objectpooler.SpawnFromPool(BulletT, ShootPoint.position, Quaternion.Euler(0, 20 / TripleAmout, 0));
                            objectpooler.SpawnFromPool(BulletT, ShootPoint.position, Quaternion.identity);
                            objectpooler.SpawnFromPool(BulletT, ShootPoint.position, Quaternion.Euler(0, -20 / TripleAmout, 0));
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
