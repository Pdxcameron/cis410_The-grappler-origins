﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Complete : MonoBehaviour
{
    void OnMouseUp()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
