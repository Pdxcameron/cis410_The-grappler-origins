using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookHolder;

    public AudioSource ShootingAudio;
    public AudioClip ShootingClip;

    public float hookTravelSpeed;
    public float playerTavelSpeed;

    //For the oscillation of the line renderer
    public float freq = 20f;
    public float magnitude = 0.5f;

    public bool hooked;
    public static bool fired;
    public GameObject hookedObject;

    public float maxDistance;
    private float currentDistance;
    private float distanceToPlayer = 20f;
    private float cpySpeed;

    private void Start()
    {
        cpySpeed = this.gameObject.GetComponent<PlayerControls>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<PlayerControls>().frozen)
        {
            //firing hook
            if (Input.GetMouseButtonDown(0) && fired == false)
            {
                ShootingAudio.clip = ShootingClip;
                ShootingAudio.Play();
                fired = true;
                hooked = false;
                hookedObject = null;
            }

            if (fired)
            {
                LineRenderer rope = hook.GetComponent<LineRenderer>();
                rope.positionCount = 2;
                rope.SetPosition(0, hookHolder.transform.position);
                rope.SetPosition(1, hook.transform.position);
            }

            if (fired == true && hooked == false)
            {
                hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
                //hook.transform.Translate(Vector3.up * Time.deltaTime * hookTravelSpeed);
                currentDistance = Vector3.Distance(transform.position, hook.transform.position); //calc distance between player and hook could use dot product or something here if we want

                if (currentDistance >= maxDistance)
                {
                    ReturnHook();
                }
            }
            if (hooked == true && fired == true) //player has attached to a valid grappling object
            {

                if (hookedObject.tag == "Hookable")
                {
                    this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    this.gameObject.GetComponent<PlayerControls>().speed = 4;
                    hook.transform.parent = hookedObject.transform;
                    transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTavelSpeed);
                    float distanceToHook = Vector3.Distance(transform.position, hook.transform.position); //calc position between player and obj/hook

                    this.GetComponent<Rigidbody>().useGravity = false;
                    if (distanceToHook < 2.5f || Input.GetMouseButtonDown(0))       //Changed this so player can get hook back
                    {
                        ReturnHook();
                    }
                }

                if (hookedObject.tag == "Grabbable" && distanceToPlayer > 3)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        hookedObject.transform.parent = null;
                        ReturnHook();
                        hookedObject.GetComponent<Rigidbody>().useGravity = true;
                        distanceToPlayer = 20f;
                    }
                    else
                    {
                        hookedObject.transform.parent = null;
                        hookedObject.transform.parent = GameObject.Find("Player").transform;
                        hookedObject.transform.position = Vector3.MoveTowards(hookedObject.transform.position, transform.position, Time.deltaTime * playerTavelSpeed);
                        LineRenderer rope = hook.GetComponent<LineRenderer>(); //This and line below smooth rope animation
                        rope.SetPosition(1, hookedObject.transform.position);  //added to have better rope
                        hook.transform.Translate(Vector3.back * Time.deltaTime * (hookTravelSpeed * 0.25f));


                        distanceToPlayer = Vector3.Distance(hookedObject.transform.position, transform.position);
                        hookedObject.GetComponent<Rigidbody>().useGravity = false;
                    }
                }

                if (hookedObject.tag == "Grabbable" && distanceToPlayer <= 3)
                {
                    //Hold();
                    hookedObject.transform.parent = null;
                    ReturnHook();
                    hookedObject.GetComponent<Rigidbody>().useGravity = true;
                    distanceToPlayer = 20f;
                }
            }

            else
            {
                hook.transform.parent = hookHolder.transform;
                this.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    public void ReturnHook()
    {
        //this.gameObject.GetComponent<PlayerControls>().speed = 8;
        this.gameObject.GetComponent<PlayerControls>().speed = cpySpeed;
        hook.transform.rotation = hookHolder.transform.rotation;
        hook.transform.position = hookHolder.transform.position;
        fired = false;
        hooked = false;

        LineRenderer rope = hook.GetComponent<LineRenderer>();
        rope.positionCount = 0;
    }
}