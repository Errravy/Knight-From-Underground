using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public  int score;
    PlayerVariable player;
    static GameManager instance;

    private void Awake() {
    if(instance != null)
    {
        Destroy(gameObject);
    }
    else
        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    private void Start() {
    }
    void Update()
    {
        
    }
}
