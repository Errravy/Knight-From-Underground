using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public void explode()
    {
        GetComponent<Animator>().SetTrigger("Explode");
        GetComponent<CircleCollider2D>().enabled = true;
        Destroy(gameObject,0.6f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Breakable")
        {
            Destroy(other.gameObject);
        }    
    }
}
