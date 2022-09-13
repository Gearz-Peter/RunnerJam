using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [Header("Stats")]
    [SerializeField]  float MovementSpeed;
    [SerializeField] float PassiveSpeed;
    [SerializeField] float DashDuration;
    [SerializeField] float DashSpeed;
    
  


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");


        if(Input.GetKey(KeyCode.S) && PassiveSpeed > 0.005f)
        {
            PassiveSpeed -= 0.1f * Time.deltaTime;

        }
        else
        {
            if (PassiveSpeed < 0.01f)
            {
                PassiveSpeed += 0.2f * Time.deltaTime;


            }
        }

        if (Input.GetKey(KeyCode.W) && PassiveSpeed < 0.02f)
        {
            PassiveSpeed += 0.1f * Time.deltaTime;

        }
        else
        {
            if (PassiveSpeed > 0.01f)
            {
                PassiveSpeed -= 0.2f * Time.deltaTime;


            }
        }


        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
       


            if(Vertical < 0 && Horizontal == 0)
            {
                StartCoroutine(DashNumerator(new Vector3(0, 0, 1)));

            }
            else
            {
                if(Vertical > 0)
                {
                    StartCoroutine(DashNumerator(new Vector3(Horizontal, 0, Vertical)));
                }
                else
                {
                    StartCoroutine(DashNumerator(new Vector3(Horizontal, 0, 0)));
                }

            }
            
            if(Vertical == 0 && Horizontal == 0)
            {
                StartCoroutine(DashNumerator(new Vector3(0, 0, 1)));

            }
        }

        controller.Move(new Vector3(0,0, PassiveSpeed ));
      controller.Move( new Vector3( Horizontal * MovementSpeed,0, 0));

        

    }
    IEnumerator DashNumerator(Vector3 Dir)
    {
        float DashElapsed = DashDuration;

        while(DashElapsed > 0)
        {
            Debug.Log("moving");

            DashElapsed -= Time.deltaTime;
            controller.Move(new Vector3(Dir.x * DashSpeed, 0, Dir.z * DashSpeed));
            yield return null;
        }
        Debug.Log("done");
        
    }
}
