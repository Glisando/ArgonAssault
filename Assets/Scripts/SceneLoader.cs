using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadScene", 2f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

}
