using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool unlocked;

    void Update()
    {
        GetComponent<Animator>().SetBool("Unlocked",unlocked);
        dooState();
    }

    void dooState()
    {
        if(unlocked)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
