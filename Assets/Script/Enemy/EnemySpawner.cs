using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] GameObject[] enemy;
    [SerializeField] int enemyGroupSize;
    [SerializeField] Transform xMin;
    [SerializeField] Transform xMax;
    [SerializeField] Transform yMin;
    [SerializeField] Transform yMax;
    public int checkEnemy;
    int randomEnemy;

    
    private void Start() 
    {
        if(boss != null)
        {
            checkEnemy = 1;
        }
        else
        {
            enemySpawn();  
        }
    }

    private void Update() {
        
    }
    void enemySpawn()
    {
        
        for(int i = 0; i < enemyGroupSize; i++)
        {
            randomEnemy = Random.Range(0,enemy.Length);
            float x = Random.Range(xMin.position.x,xMax.position.x);
            float y = Random.Range(yMin.position.y,yMax.position.y);
            Vector3 randomPos = new Vector3(x,y,transform.position.z);
            Instantiate(enemy[randomEnemy],randomPos,Quaternion.identity);
            checkEnemy++;
        }
    }
}
