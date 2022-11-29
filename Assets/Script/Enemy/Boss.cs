using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    Enemy enemy;
    [SerializeField] Slider HealthBar;

    private void Awake() {
        enemy = GetComponent<Enemy>();
        HealthBar.maxValue = enemy.health;
    }

    private void Update() {
        HealthBar.value = enemy.health;
        dead();
    }

    void dead()
    {
        if(enemy.health <= 0)
        {
            FindObjectOfType<LevelManager>().Invoke("GameOver",3f);
        }
    }

}
