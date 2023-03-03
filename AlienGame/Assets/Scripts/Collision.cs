using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    private SceneManager sceneManager;
    // Start is called before the first frame update

    void Start()
    {
        sceneManager = GetComponent<SceneManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            sceneManager.LoadScene(LoseSceneTemp);
        }
    }
}