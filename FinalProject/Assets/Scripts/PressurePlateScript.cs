using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    public GameObject toggle;
    public bool inverse = false;
    public float speed = 1.0f;
    public float drop = -0.15f;
    private readonly List<GameObject> currentCollisions = new List<GameObject>();
    private Vector3 downPosition;
    private Vector3 upPosition;

    void Start()
    {
        upPosition = transform.position;
        Vector3 temp = new Vector3(0, drop, 0);
        downPosition = upPosition + temp;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Grabbable"))
        {  
            if (!currentCollisions.Contains(other.gameObject))
            {
                currentCollisions.Add(other.gameObject);
            }
            transform.position = downPosition;
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
                transform.position = upPosition;
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
