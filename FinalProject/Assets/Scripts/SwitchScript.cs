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
            if (hitColliders[i].gameObject.name == "Player")
            {
                if (Input.GetKeyDown("e"))
                {
                    if (bridge.active)
                    {
                        bridge.SetActive(false);
                        GetComponent<Renderer>().material.color = Color.red;
                    }
                    else
                    {
                        bridge.SetActive(true);
                        GetComponent<Renderer>().material.color = Color.green;
                    }
                }
            }
            i++;
        }
    }
}
