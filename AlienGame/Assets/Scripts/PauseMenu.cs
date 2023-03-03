using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private InputManager inputManager;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        pauseMenu = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputManager.onFoot.Pause.triggered)
        {
            pauseMenu.SetActive(true);
        }
    }
}
