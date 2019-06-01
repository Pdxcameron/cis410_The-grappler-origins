using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleEntryTrigger : MonoBehaviour
{
    public GameObject position;

    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.name == "Player")
        {
            FindObjectOfType<GateDropper>().stopGate();
            collide.gameObject.SetActive(false);
            collide.gameObject.transform.position = position.transform.position;
            collide.gameObject.SetActive(true);
        }
    }
}
