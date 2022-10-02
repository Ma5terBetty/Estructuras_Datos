using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void OptionsButton()
    {
        Debug.Log("Ya está activado el RTX, no molestes");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void Credits()
    {
        
    }
}
