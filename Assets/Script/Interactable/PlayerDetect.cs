using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] GameObject currentDoor;
    [SerializeField] GameObject key;
    [SerializeField] GameObject bossUI;
    EnemySpawner spawner;
    public bool playerInRoom = false;
    private void Awake() {
        spawner = GetComponent<EnemySpawner>();
    }
    private void Start() {
        
    }
    private void Update() {
        enemyCount();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            if(bossUI != null){bossControl();}
                spawner.enabled = true;
                currentDoor.GetComponent<Door>().unlocked = false;
                playerInRoom = true;
        }
    }
    void enemyCount()
    {
        if(spawner.enabled != false)
        {
            if(spawner.checkEnemy <= 0)
            {
                spawnKey();
                if(bossUI != null){bossUI.SetActive(false);}
                currentDoor.GetComponent<Door>().unlocked = true;
                playerInRoom = false;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    void spawnKey()
    {
        if(key != null)
        {
            key.SetActive(true);
        }
        else return;
    }

    void bossControl()
    {
        if(bossUI != null && spawner.checkEnemy >= 0) 
        {
            bossUI.SetActive(true);
        }
        else if(spawner.checkEnemy <= 0)
        {
            bossUI.SetActive(false);
        }
    }
}
