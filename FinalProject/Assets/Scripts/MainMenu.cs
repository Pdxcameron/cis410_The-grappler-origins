﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool newGame;
    public bool exit;
    public bool tutorial;
    public bool menu;

    void OnMouseUp()
    {
        if (newGame)
        {
            SceneManager.LoadScene("Level1");
        }
        if (exit)
        {
            Application.Quit();
        }
        if (tutorial)
        {
            SceneManager.LoadScene("POCScene");
        }
        if (menu)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}
