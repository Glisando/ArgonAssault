using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleController : MonoBehaviour
{
    ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        explosion = gameObject.GetComponent<ParticleSystem>();
        Play();
    }

    public void Play()
    {
        explosion.Play();
    }
}
