using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onDeath : MonoBehaviour
{
    [SerializeField] private GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            if (Random.Range(0f, 1f) > .7)
            {
                Instantiate(item, this.gameObject.transform.position, new Quaternion(0, 0, 0, 1));
            }
            Destroy(this.gameObject);
        }
    }
}
