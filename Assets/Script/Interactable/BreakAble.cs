using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAble : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Explosion")
        {
            Destroy(gameObject);
        }
    }
}
