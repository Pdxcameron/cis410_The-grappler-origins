using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainGrapple : MonoBehaviour
{
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, 3);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].name == "Player")
            {
                if (Input.GetKeyDown("e"))
                {
                    hitColliders[i].gameObject.GetComponent<GrapplingHook>().enabled = true;
                    hitColliders[i].gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                }
            }
            i++;
        }
    }

}
