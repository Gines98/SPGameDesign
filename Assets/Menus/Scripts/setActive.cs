using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hideAtTheBeginning : MonoBehaviour
{
    public GameObject Buttons;
    void Start()
    {
        Buttons.SetActive(false);
    }
}
