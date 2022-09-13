using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    int Dashes=3;
    float DashRegen=1.5f;
    float DashRegenRefresh;
    float DashCooldown=0.05f;
    float DashCooldownRefresh;
    [Header("Stats")]
    [SerializeField]  float MovementSpeed;
    [SerializeField] float PassiveSpeed;
    [SerializeField] float DashDuration;
    [SerializeField] float DashSpeed;
    [SerializeField] DashTrail Trailer;
    [SerializeField] int maxDashes;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        

        if (Dashes < maxDashes)
        {
           
            if (DashRegenRefresh <= 0)
            {
              
                DashRegenRefresh = DashRegen;
                Dashes++;
            }
           else
            {
                DashRegenRefresh -= Time.deltaTime;
            }
        }


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

        if(DashCooldownRefresh > -1)
        {
            DashCooldownRefresh -= Time.deltaTime;
        }


        if(Input.GetKeyDown(KeyCode.LeftShift) && DashCooldownRefresh < 0 && Dashes > 0)
        {
            DashCooldownRefresh = DashCooldown;
            Dashes--;

            if (Vertical == 0 && Horizontal == 0)
            {
                StartCoroutine(DashNumerator(new Vector3(0, 0, 1)));

            }
            else
            {
                if (Vertical < 0 && Horizontal == 0)
                {
                    StartCoroutine(DashNumerator(new Vector3(0, 0, 1)));

                }
                else
                {
                    if (Vertical > 0)
                    {
                        StartCoroutine(DashNumerator(new Vector3(Horizontal, 0, Vertical)));
                    }
                    else
                    {
                        StartCoroutine(DashNumerator(new Vector3(Horizontal, 0, 0)));
                    }

                }
            }

         
            
            
        }

        controller.Move(new Vector3(0,0, PassiveSpeed ));
      controller.Move( new Vector3( Horizontal * MovementSpeed,0, 0));

        

    }
    IEnumerator DashNumerator(Vector3 Dir)
    {
        float DashElapsed = DashDuration;
        Trailer.StartTrail();
        while (DashElapsed > 0)
        {
           
            DashElapsed -= Time.deltaTime;
            controller.Move(new Vector3(Dir.x * DashSpeed * Time.deltaTime, 0, Dir.z * DashSpeed * Time.deltaTime));
            yield return null;
        }
        Trailer.EndTrail();

      
        
    }
}
