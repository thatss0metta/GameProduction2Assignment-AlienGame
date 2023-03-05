using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Flashable : MonoBehaviour
{
    // Displayed when player is looking at flashable
    public string flashMessage;
    

    public void BaseFlash()
    {
        Flash();
    }
  
    protected virtual void Flash()
    {
        // No code in this function
        // Template function to be overridden by subclasses
    }
}
