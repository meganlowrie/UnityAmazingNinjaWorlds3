using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
        PlayerPrefs.DeleteKey("LIVES_LEFT");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
       // PlayerPrefs.DeleteKey("LIVES_LEFT");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
        //PlayerPrefs.DeleteKey("LIVES_LEFT");
    }
}
