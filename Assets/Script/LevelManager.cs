using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    int currentScene;
    [SerializeField] GameObject player;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void nextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
        if(player != null) player.transform.position = new Vector3(0,0,0);
    }

    public void GameOver()
    {
        if(player != null){player.SetActive(false);}
        SceneManager.LoadScene("GameOver");
        
    }
}
