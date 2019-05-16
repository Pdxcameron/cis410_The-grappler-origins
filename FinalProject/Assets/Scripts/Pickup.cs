using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject holdPos;

    private bool playerInRange;
    private bool holding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Hold()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.parent = holdPos.transform;
        holding = true;
    }

    void Drop()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        holding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((playerInRange && Input.GetKeyDown("e")) && !holding)
        {
            Debug.Log("Picked up object");
            Hold();
        }
        if(holding && Input.GetKeyDown("r"))
        {
            Debug.Log("attempting to drop object");
            Drop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            playerInRange = false;
        }
    }
}
