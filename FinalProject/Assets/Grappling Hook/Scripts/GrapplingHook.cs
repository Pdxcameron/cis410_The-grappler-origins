﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookHolder;

    public float hookTravelSpeed;
    public float playerTavelSpeed;

    public bool hooked;
    public static bool fired;
    public GameObject hookedObject;

    public float maxDistance;
    private float currentDistance;

    private bool grounded;


    // Update is called once per frame
    void Update()
    {
        //firing hook
        if (Input.GetMouseButtonDown(0) && fired == false)
        {
            fired = true;
        }

        if (fired)
        {
            LineRenderer rope = hook.GetComponent<LineRenderer>();
            rope.SetVertexCount(2);
            rope.SetPosition(0, hookHolder.transform.position);
            rope.SetPosition(1, hook.transform.position);
        }

        if (fired == true && hooked == false)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position); //calc distance between player and hook could use dot product or something here if we want

            if (currentDistance >= maxDistance)
            {
                ReturnHook();
            }
        }
        if (hooked == true && fired == true) //player has attached to a valid grappling object
        {
            hook.transform.parent = hookedObject.transform;

            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTavelSpeed);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position); //calc position between player and obj/hook

            this.GetComponent<Rigidbody>().useGravity = false;

            if (distanceToHook < 2)
            {
                ReturnHook();
            }
        }
        else
        {
            hook.transform.parent = hookHolder.transform;
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void ReturnHook()
    {
        hook.transform.rotation = hookHolder.transform.rotation;
        hook.transform.position = hookHolder.transform.position;
        fired = false;
        hooked = false;

        LineRenderer rope = hook.GetComponent<LineRenderer>();
        rope.SetVertexCount(0);
    }

    void CheckGrounded()
    {
        RaycastHit hit;
        float distance = 1f;

        Vector3 direction = new Vector3(0, -1);

        if(Physics.Raycast(transform.position, direction, out hit, distance))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
}
