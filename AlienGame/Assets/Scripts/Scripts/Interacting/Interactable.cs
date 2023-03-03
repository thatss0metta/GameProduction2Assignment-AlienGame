using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Displayed when player is looking at interactable
    public string promptMessage;
    

    public void BaseInteract()
    {
        Interact();
    }
  
    protected virtual void Interact()
    {
        // No code in this function
        // Template function to be overridden by subclasses
    }
}
