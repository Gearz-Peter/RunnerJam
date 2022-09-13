using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k") == true)
        {
            Instantiate(enemyPrefab, this.gameObject.transform) ;
        }
    }
}
