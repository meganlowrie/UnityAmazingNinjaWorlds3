using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public ParticleSystem allParticles;

    // Update is called once per frame
    public void On()
    {
        allParticles.Play();
    }
}
