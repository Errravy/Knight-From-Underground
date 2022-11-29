using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    PolygonCollider2D polygon;
    void Awake()
    {
        polygon = GetComponent<PolygonCollider2D>();
    }

    public void attack(int i)
    {
        if(i == 0)
        {
            polygon.enabled = true;
        }
        else
            polygon.enabled = false;
    }
}
