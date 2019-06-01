using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public Text nameText;
    public Text popupText;

    private GameObject box;
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        box = GameObject.Find("PopupBox");
        GameObject.Find("PopupBox").SetActive(false);
        sentences = new Queue<string>();
    }

    public void StartPopup(PopupInfo info)
    {
        FindObjectOfType<PlayerControls>().frozen = true;

        Cursor.lockState = CursorLockMode.None;

        nameText.text = info.name;
        sentences.Clear();
        box.SetActive(true);

        foreach(string sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndPopup();
            return;
        }

        string s = sentences.Dequeue();
        popupText.text = s;
        StopAllCoroutines();
        StartCoroutine(WaitForInstruction());
    }

    //IEnumerator TypeSentence (string sentence)
    //{
    //    popupText.text = "";
    //    foreach (char letter in sentence.ToCharArray())
    //    {
    //        popupText.text += letter;
    //        yield return null;
    //    }
    //}

    IEnumerator WaitForInstruction() // https://answers.unity.com/questions/904427/waiting-for-a-mouse-click-in-a-coroutine.html
    {
        yield return new WaitForSeconds(0.5f);
        var pressed = false;
        while (!pressed)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                pressed = true;
            }
            yield return null;
        }
        DisplayNextSentence();
        yield break;
    }

    void EndPopup()
    {
        box.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<PlayerControls>().frozen = false;
    }
}
