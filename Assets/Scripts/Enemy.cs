using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);

        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
