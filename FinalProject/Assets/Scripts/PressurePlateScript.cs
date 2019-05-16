using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    public GameObject toggle;
    public bool inverse = false;
    private List<GameObject> currentCollisions = new List<GameObject>();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Grabbable"))
        {
            if (!currentCollisions.Contains(other.gameObject))
            {
                currentCollisions.Add(other.gameObject);
            }
            if (!inverse)
            {
                toggle.SetActive(false);
            }
            else
            {
                toggle.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentCollisions.Contains(other.gameObject))
        {
            currentCollisions.Remove(other.gameObject);
        }
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Grabbable"))
        {
            if(currentCollisions.Count == 0)
            {
                if (!inverse)
                {
                    toggle.SetActive(true);
                }
                else
                {
                    toggle.SetActive(false);
                }
            }
        }
    }
}
