using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class MoveNextLevel : MonoBehaviour
{
    public ScoreScript game;
    private int LoadNext;
    private int bossscene = 6;
    void Start()
    {
        LoadNext = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter2D(Collider2D a)
    {
        if(game.win == true)
        {
            if (a.tag == "EndPoint")
            {
                if (SceneManager.GetActiveScene().buildIndex == 10)
                {
                    Debug.Log("You win the game");
                }
                SceneManager.LoadScene(LoadNext);

                if (LoadNext > PlayerPrefs.GetInt("currentLevel"))
                {
                    PlayerPrefs.SetInt("currentLevel", LoadNext);
                }
            }
        }else if(game.loose == true)
        {
            if (a.tag == "EndPoint")
            {

                SceneManager.LoadScene(bossscene);

            }

        }
        
    }
}
