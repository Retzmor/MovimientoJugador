using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
   
    public void ChangeScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnApplicationQuit()
    {
            Application.Quit();
    }
}


