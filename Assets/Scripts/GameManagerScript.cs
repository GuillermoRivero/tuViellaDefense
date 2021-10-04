using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    public static bool GameIsOver;
    public GameObject gameOverUI;

    void Start () {
        GameIsOver = false;
    }

    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one GameManagerScript running!");
            return;
        } 
        instance = this;
    }
    
    void Update()
    {
        if (GameIsOver) return;

        if (Input.GetKeyDown("e")) {
            EndGame();
        }

        if (PlayerStats.Lives <= 0){
            EndGame();
        }
    }

    void EndGame() {
        if (!GameIsOver) {
            GameIsOver = true;
            gameOverUI.SetActive(true);
        }
    }
}
