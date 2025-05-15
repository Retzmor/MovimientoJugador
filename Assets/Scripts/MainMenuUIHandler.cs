using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIHandler : MonoBehaviour
{
    [SerializeField] GameObject Menu, options;
   

    public void ShowOptions()
    {
        options.SetActive(true);
    }

    public void ShowMenu()
    {
        options.SetActive(false);
    }
}
