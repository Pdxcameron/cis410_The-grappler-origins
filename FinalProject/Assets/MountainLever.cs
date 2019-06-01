using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainLever : MonoBehaviour
{
    private Transform pivot;

    private bool down = false;
    void Start()
    {
        pivot = this.gameObject.transform.parent;
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 5);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].name == "Player")
            {
                if (Input.GetKeyDown("e") && !down)
                {
                    pivot.rotation = Quaternion.identity;
                    down = true;
                    FindObjectOfType<RockDrop>().dropRock();
                    break;
                }
            }
            i++;
        }
    }
}
