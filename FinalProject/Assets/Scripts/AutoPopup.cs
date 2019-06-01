using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPopup : MonoBehaviour
{
    public PopupInfo popup;

    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.name == "Player")
        {
            TriggerPopup();
        }
    }

    public void TriggerPopup()
    {
        FindObjectOfType<PopupManager>().StartPopup(popup);
        this.gameObject.SetActive(false);
    }
}
