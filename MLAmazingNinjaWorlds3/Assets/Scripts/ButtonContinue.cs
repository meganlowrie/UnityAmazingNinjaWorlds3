using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonContinue : MonoBehaviour
{
    public void Reset()
    {
        //SceneManager.LoadScene(0);
    }

    public void Sublevel()
    {
        SceneManager.LoadScene("Level1_A", LoadSceneMode.Single);
    }
}
