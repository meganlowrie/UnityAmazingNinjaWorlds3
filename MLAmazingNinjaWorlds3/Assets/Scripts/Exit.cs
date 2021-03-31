using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    SpriteRenderer m_renderer;
    public GameObject gem;
    public GameObject background;
    public string teleportDestination;

    private AudioSource teleportActive;

    private void Start()
    {
        m_renderer = gem.GetComponent<SpriteRenderer>();
        teleportActive = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(m_renderer.enabled == false && teleportActive.isPlaying == false)
        {
            teleportActive.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(m_renderer.enabled == false)
        {
            background.GetComponent<GameManager>().TeleportOpen(teleportDestination);
        }

    }
}
