using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTrigger : MonoBehaviour
{
    public PopupInfo popup;
    public float radius;

    private Vector3 center;

    void Start()
    {
        center = this.transform.position;
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].name == "Player")
            {
                if (Input.GetKeyDown("e"))
                {
                    TriggerPopup();
                    break;
                }
            }
            i++;
        }
    }

    public void TriggerPopup()
    {
        FindObjectOfType<PopupManager>().StartPopup(popup); 
    }
}
