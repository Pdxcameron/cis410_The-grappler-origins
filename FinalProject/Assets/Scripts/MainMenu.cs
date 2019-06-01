using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool newGame;
    public bool exit;

    void OnMouseUp()
    {
        if (newGame)
        {
            SceneManager.LoadScene("Level1Start");
        }
        if (exit)
        {
            Application.Quit();
        }
    }

}
