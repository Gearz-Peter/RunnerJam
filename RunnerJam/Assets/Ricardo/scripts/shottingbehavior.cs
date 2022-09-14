using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shottingbehavior : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    [Header("Shottin Stats")]

    [SerializeField] float frecuency;
    [SerializeField] float speedShot;

    [SerializeField] float frecuencyRound;
    [SerializeField] int numberBulletPerShot;

    [SerializeField] bool wave;
    [SerializeField] float numberBullets;
    [SerializeField] float initialAngle;
    [SerializeField] float endAngle;
    float angle;
    int angleIndex;
    int angleStep;
    int currentBullets ;


    float currentTime;
    float previousTime;
    float previousBulletTime;
    Transform enemyTransform;
    GameObject tmp;
    bullet tmpBullet;

    // Start is called before the first frame update
    void Start(){

        currentTime = 0.0f;
        previousTime = 0.0f;
        previousBulletTime = 100.0f;
        enemyTransform = GetComponent<Transform>();

        angle = endAngle - initialAngle;
        angle = angle / numberBullets;
        angleIndex = 0;
        angleStep = 1;

        currentBullets = numberBulletPerShot;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime - previousTime >= frecuency)
        {
            angle = endAngle - initialAngle;
            angle = angle / (numberBullets - 1);

            if (wave)
            {
                for (int i = 0; i < numberBullets; i++)
                {
                    shotBullet(i);
                }
            }
            else
            {
                //Single
                shotBullet(angleIndex);

                previousBulletTime = currentTime;
                currentBullets = numberBulletPerShot;
                angleIndex += angleStep;
                if (angleIndex >= numberBullets - 1) { angleStep = -1; }
                if (angleIndex <= 0) { angleStep = 1; }

            }

            previousTime = currentTime;
        }

        // Semiautomatic
        if(frecuencyRound > frecuency)
        {
            frecuencyRound = frecuency / numberBulletPerShot;
        }
       
        if (currentBullets > 1) {
            
            if (currentTime - previousBulletTime >= frecuencyRound)
            {
                shotBullet(angleIndex);
                previousBulletTime = currentTime;
                currentBullets--;
                Debug.Log("aaa");
            }
        }
        else
        {
            
        }
    }

    private void shotBullet(int bulletAngle)
    {
        Vector3 newRotation = new Vector3(0.0f, initialAngle + (angle * (float)bulletAngle), 0.0f);
        Quaternion newQRot = enemyTransform.rotation;
        newQRot.eulerAngles += newRotation;

        tmp = Instantiate(bulletPrefab, enemyTransform.position + enemyTransform.forward, newQRot);
        tmpBullet = tmp.GetComponent<bullet>();
        tmpBullet.shot(speedShot);
    }
}
