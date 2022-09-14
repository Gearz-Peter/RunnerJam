using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    float speed;

    Transform bulletTransform;

    // Start is called before the first frame update
    void Start()
    {
        bulletTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //forWardMovement
        bulletTransform.Translate(new Vector3(0.0f, 0.0f, 1.0f) * speed * Time.deltaTime);
    }

    public void shot(float speed)
    {
        this.speed = speed;
    }
}
