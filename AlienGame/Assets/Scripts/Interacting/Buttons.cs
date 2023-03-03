using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : Interactable
{
    public Animator door;
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
        if(door.GetBool("open") == false)
            door.SetBool("open", true);
        else
            door.SetBool("open", false);
    }
}