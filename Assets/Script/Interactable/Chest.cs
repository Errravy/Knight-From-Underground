using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Chest : MonoBehaviour
{
    bool canOpenChest = false;
    [SerializeField] GameObject[] loot;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            canOpenChest = true;
        }    
    }

    public void openChest()
    {
            GetComponent<Animator>().SetTrigger("Unlocked");    
    }

    public void drop()
    {
        Instantiate(loot[Random.Range(0,loot.Length)],transform.position,Quaternion.identity);
    }
}
