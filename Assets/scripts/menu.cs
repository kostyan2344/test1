using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene("game");
    }
    public void exit()
    { 
        Application.Quit();
    }
}
