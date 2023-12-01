using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    public GameObject SubButtons;
    public void ToggleCanvasVisibility()
    { 
        if(SubButtons != null)
        {
            SubButtons.SetActive(!SubButtons.activeSelf);
        }
    }
}
