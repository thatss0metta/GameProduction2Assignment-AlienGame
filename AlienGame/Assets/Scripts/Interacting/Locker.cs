using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : Interactable
{
    public Animator locker;
    public AudioClip lockerDoor;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource != null)
            audioSource.clip = lockerDoor;
    }
    protected override void Interact()
    {
        audioSource.Play();
        if(locker.GetBool("open") == false)
            locker.SetBool("open", true);
        else
            locker.SetBool("open", false);
    }
}