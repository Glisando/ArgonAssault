using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] float lvlLoadDelay = 2f;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    void StartDeathSequence()
    {
        explosion.GetComponent<ParticleController>().Play();
        gameObject.GetComponent<PlayerController>().OnPlayerDeath();
        Invoke("ReloadLevel", lvlLoadDelay);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
