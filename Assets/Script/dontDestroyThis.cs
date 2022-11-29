using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyThis : MonoBehaviour
{
    static dontDestroyThis instance;

    // private void Awake() {
    //     if(instance != null)
    //     {
    //         Destroy(gameObject);
    //     }
    //     else
    //     instance = this;
    //     DontDestroyOnLoad(gameObject);
        
    // }

    private void Start() {
        transform.position = new Vector3(0,0,0);
    }
}
