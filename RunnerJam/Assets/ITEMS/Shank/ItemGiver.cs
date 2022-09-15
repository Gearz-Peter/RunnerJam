using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    [SerializeField]string ItemName;
    public bool active;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && active)
        {
            Debug.Log("touch");
            other.GetComponent<PlayerShooting>().AddNewItem(ItemName);


        }
    }
}
