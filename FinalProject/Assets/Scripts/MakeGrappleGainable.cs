using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGrappleGainable : MonoBehaviour
{
    public GameObject jar;

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, 5);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].name == "Player")
            {
                if (Input.GetKeyDown("e"))
                {
                    freeGrapple();
                    break;
                }
            }
            i++;
        }
    }

    public void freeGrapple()
    {
        jar.gameObject.GetComponent<GainGrapple>().enabled = true;
        jar.gameObject.GetComponent<PopupTrigger>().enabled = true;
    }
}
