using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool newGame;
    public bool exit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

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
