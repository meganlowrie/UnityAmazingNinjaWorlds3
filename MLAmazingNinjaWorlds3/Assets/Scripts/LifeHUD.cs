using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeHUD : MonoBehaviour
{
    GameObject[] heart;
    public GameObject background;
    public GameObject player;
    public int lives = 3;

    public void Awake()
    {
        heart = GameObject.FindGameObjectsWithTag("heart");
        if (PlayerPrefs.HasKey("LIVES_LEFT"))
        {
            lives = PlayerPrefs.GetInt("LIVES_LEFT");
            HUDRefresh();
        }

    }

    public void Hurt()
    {
        lives -= 1;
        saveData();
        HUDRefresh();        
    }

    public void HUDRefresh()
    {
        {
            for (int life = 0; life < heart.Length; life++)
            {
                if (life < lives)
                {
                    heart[life].SetActive(true);
                }
                else
                {
                    heart[life].SetActive(false);
                }
            }

            if (lives <= 0)
            {
                //GAMEOVER
                background.GetComponent<GameManager>().GameOver();
            }
        }
    }

    public void saveData()
    {
        PlayerPrefs.SetInt("LIVES_LEFT", lives);
    }
}
