using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JailExitTrigger : MonoBehaviour
{
    public GameObject position;
    public GameObject gate;

    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.name == "Player")
        {
            collide.gameObject.SetActive(false);
            collide.gameObject.GetComponent<GrapplingHook>().ReturnHook();
            collide.gameObject.transform.position = position.transform.position;
            gate.transform.rotation = Quaternion.Euler(-85, 0, 0);
            collide.gameObject.SetActive(true);
        }
    }
}
