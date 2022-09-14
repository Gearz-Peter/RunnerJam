using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shottingbehavior : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    [Header("Shottin Stats")]

    [SerializeField] float frecuency;
    [SerializeField] float speedShot;

    [SerializeField] bool wave;
    [SerializeField] float numberBullets;
    [SerializeField] float numberWaves;
    [SerializeField] float initialAngle;
    [SerializeField] float endAngle;
    float angle;
    int angleIndex;
    int angleStep;



    float currentTime;
    float previousTime;
    Transform enemyTransform;
    GameObject tmp;
    bullet tmpBullet;




    // Start is called before the first frame update
    void Start(){

        currentTime = 0.0f;
        previousTime = 0.0f;
        enemyTransform = GetComponent<Transform>();

        angle = endAngle - initialAngle;
        angle = angle / numberBullets;
        angleIndex = 0;
        angleStep = 1;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime - previousTime >= frecuency)
        {
            angle = endAngle - initialAngle;
            angle = angle / (numberBullets - 1);

            if (wave)
            {
               
                for(int i = 0; i < numberBullets; i++)
                {
                    Vector3 newRotation = new Vector3(0.0f, initialAngle + (angle * (float)i), 0.0f);
                    Quaternion newQRot = enemyTransform.rotation;
                    newQRot.eulerAngles += newRotation;
                    tmp = Instantiate(bulletPrefab, enemyTransform.position + enemyTransform.forward, newQRot);

                    tmpBullet = tmp.GetComponent<bullet>();
                    tmpBullet.shot(speedShot);
                }
            }
            else
            {
                Vector3 newRotation = new Vector3(0.0f, initialAngle + (angle * (float)angleIndex), 0.0f);
                Quaternion newQRot = enemyTransform.rotation;
                newQRot.eulerAngles += newRotation;

                angleIndex += angleStep;

                if(angleIndex >= numberBullets){ angleStep = -1; }
                if(angleIndex < 0){ angleStep = 1; }

                tmp = Instantiate(bulletPrefab, enemyTransform.position + enemyTransform.forward, newQRot);
                tmpBullet = tmp.GetComponent<bullet>();
                tmpBullet.shot(speedShot);
            }
            
            previousTime = currentTime;
        }
    }
}
