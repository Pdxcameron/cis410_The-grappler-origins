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
        Debug.Log("Trigger has been pressed");
        toggle.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger is no longer being pressed.");
        toggle.SetActive(true);
    }
}
