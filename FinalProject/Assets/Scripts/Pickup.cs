using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject holdPos;
    private float BoxSpeed = 1000f;

    private bool playerInRange;
    public bool holding = false;
    private GameObject player;

    Rigidbody ThisRigidBody;

    IEnumerator HoldingPosition()
    {
        var prevPos = this.transform.position;
        while (holding)
        {
            var changeInPos = holdPos.transform.position - prevPos;
            prevPos = this.transform.position;
            ThisRigidBody.velocity = BoxSpeed * changeInPos * Time.deltaTime;
            yield return null;
        }
    }

    private void Start()
    {
        ThisRigidBody = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    void Hold()
    {
        this.transform.parent = null;
        ThisRigidBody.useGravity = false;
        this.gameObject.layer = 12;
        holding = true;
        StartCoroutine(HoldingPosition());
    }

    public void Drop()
    {
        this.transform.parent = null;
        ThisRigidBody.useGravity = true;
        this.gameObject.layer = 0;
        holding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && Input.GetKeyDown("e") && !holding)
        {
            Debug.Log("Picked up object");
            player.gameObject.GetComponent<PlayerControls>().heldCube = this.gameObject;
            Hold();
        }
        else if(holding && Input.GetKeyDown("e"))
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
