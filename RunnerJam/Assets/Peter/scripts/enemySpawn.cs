using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawntime;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += .02f;

        if (time > spawntime && Random.Range(0f, 1f) > .99)
        {
            Instantiate(enemyPrefab, this.gameObject.transform);
            time = 0;
            spawntime = Mathf.Lerp(spawntime, 1, .1f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            Instantiate(enemyPrefab, this.gameObject.transform);
        }
    }
}
