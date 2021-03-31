using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject popUp;
    public TextMeshProUGUI textMessage;
    public GameObject player;
    public Vector3 checkPoint = new Vector3(-4.7f, 0.6f, 0);
    public GameObject retryButton;
    public TextMeshProUGUI buttonText;

    private AudioSource buttonSound;
    public AudioClip ButtonClick;
    public AudioClip Win;

    // Start is called before the first frame update
    void Start()
    {
        popUp.SetActive(false);
        buttonSound = GetComponent<AudioSource>();
        //for testing only. Remove for final.
        //PlayerPrefs.DeleteKey("LIVES_LEFT");
    }

    private void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void GameOver()
    {
        textMessage.text = "Keep Trying!";
        retryButton.GetComponent<Button>().onClick.AddListener(delegate { Reset("Level1"); });
        buttonText.text = "Click to try again";
        popUp.SetActive(true);
        PlayerPrefs.DeleteKey("LIVES_LEFT");
    }

    public void TeleportOpen(string nextScene)
    {
        textMessage.text = "Good Job!";
        retryButton.GetComponent<Button>().onClick.AddListener(delegate { Reset(nextScene); });
        buttonText.text = "Click to continue";
        popUp.SetActive(true);
        buttonSound.PlayOneShot(Win);
        if(nextScene == "Level1")
        {
            PlayerPrefs.DeleteKey("LIVES_LEFT");
        }
    }

    public void moveToCheckPoint()
    {
        player.transform.position = checkPoint;
    }

    public void UpdateCheckPoint(Vector3 newCheckPoint)
    {
        checkPoint = newCheckPoint;
    }

    public void Reset(string sceneName)
    {
        buttonSound.clip = ButtonClick;
        buttonSound.Play();
        StartCoroutine(buttonPress(sceneName));
        //SceneManager.LoadScene(sceneName);
    }

    IEnumerator buttonPress(string name)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(name);
    }

}
