using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    SpriteRenderer m_renderer;
    public ParticleSystem m_particle;

    public ParticleSystem allParticles;

    private AudioSource collectSound;

    private void Start()
    {
        m_renderer = GetComponentInParent<SpriteRenderer>();
        collectSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_particle.isPlaying)
        {
            m_renderer.enabled = false;
            m_particle.Stop();
            allParticles.Play();
            collectSound.Play();
            //Debug.Log("Hit!");
        }
    }

}
