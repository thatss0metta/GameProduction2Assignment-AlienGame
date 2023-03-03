using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButton : Interactable
{
    public Animator door;
    private SceneManager sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GetComponent<SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
       //sceneManager.LoadScene(WinScene);
    }
}