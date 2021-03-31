using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    //The object which has the LifeHUD script
    public GameObject hud;
    //The object which has the GameManager script
    public GameObject background;

    private AudioSource hitSound;

    private void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    //When anything (currently only the player is possible) touches this object.
    private void OnTriggerEnter(Collider other)
    {
        hitSound.Play();
        
        //Move the player to the last checkpoint
        background.GetComponent<GameManager>().moveToCheckPoint();

        //Apply damage and display it. (also end game if all lives are gone).
        hud.GetComponent<LifeHUD>().Hurt();
    }
}
