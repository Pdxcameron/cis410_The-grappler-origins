using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    public GameObject toggle;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        toggle.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        toggle.SetActive(true);
    }
}
