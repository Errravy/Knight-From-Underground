using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using TMPro;

public class PlayerVariable : MonoBehaviour
{
    [HideInInspector] public Vector2 direction;
    public float moveSpeed;
    PlayerVariable instance;

    public int health;
    public int coin;
    public static int lastScore;
    public Image key;
    public Image bombUI;
    public Slider healthBar;
    public TextMeshProUGUI coinText;
    public GameObject canvas;
    public LayerMask enemy;
    public GameObject bomb;
    public Color32 invisible;
    public Color32 normal;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        healthBar.maxValue = health;
    }
    private void Update() {
        lastScore = coin;
    }
}
