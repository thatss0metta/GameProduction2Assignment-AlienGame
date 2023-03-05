using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : Interactable
{
    public Animator door;
    public AudioClip doorOpen;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource == null)
        {
            Debug.LogError("No audioSource bro :(");
        }
        else
        {
            audioSource.clip = doorOpen;
        }
    }
    protected override void Interact()
    {
        audioSource.Play();
        if(door.GetBool("open") == false)
        {
            door.SetBool("open", true);
        }
        else
            door.SetBool("open", false);
    }
}