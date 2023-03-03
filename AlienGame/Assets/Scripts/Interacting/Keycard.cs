using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : Interactable
{
    public PlayerMotor playerMotor;
    public GameObject keycard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        playerMotor.hasKey = true;
        keycard.SetActive(false);
    }
}