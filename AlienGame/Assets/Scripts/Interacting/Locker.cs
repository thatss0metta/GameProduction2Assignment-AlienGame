using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : Interactable
{
    public Animator locker;
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
        if(locker.GetBool("open") == false)
            locker.SetBool("open", true);
        else
            locker.SetBool("open", false);
    }
}