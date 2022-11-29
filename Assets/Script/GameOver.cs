using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private void Awake() {
       
    }
    private void Start() {
         
        
    }
    private void LateUpdate() {
        scoreText.text = "Score: " + PlayerVariable.lastScore.ToString();
    }
}
