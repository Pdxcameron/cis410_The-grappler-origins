using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public GameObject bridge;
    public float sphereRadius;

    // Start is called before the first frame update
    void Start()
    {
        if (bridge == null)
            bridge = GameObject.Find("Bridge");
        if (bridge.active)
            bridge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphereRadius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            Debug.Log(hitColliders[i].gameObject.name);
            if (hitColliders[i].gameObject.name == "Player")
            {
                Debug.Log("Found Player");
                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("'E' Registered");
                    if (bridge.active)
                        bridge.SetActive(false);
                    else
                        bridge.SetActive(true);
                }
            }
            i++;
        }
    }
}
