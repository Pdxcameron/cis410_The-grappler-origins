using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public float speed;
    public GameObject heldCube;
    public GameObject jar;

    public AudioSource ConstantAudio;
    public AudioClip ConstantClip;
    public AudioSource FootstepAudio;
    public AudioClip FootstepClip;

    public GameObject checkpoint;
    private Rigidbody player;
    private bool grounded;
    private bool inAir;
    private bool playing;
    public bool frozen;

    // Start is called before the first frame update
    void Start()
    {
        ConstantAudio.loop = true;

        playing = false;
        frozen = false;
        player = GetComponent<Rigidbody>();

        checkpoint = GameObject.Find("start_checkpoint");
        //For First person camera handling
        Cursor.lockState = CursorLockMode.Locked;

        if(SceneManager.GetActiveScene().name == "Level1")
        {
            this.gameObject.GetComponent<GrapplingHook>().enabled = false;
            jar.gameObject.GetComponent<GainGrapple>().enabled = false;
            jar.gameObject.GetComponent<PopupTrigger>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!frozen)
        {
            if (Input.GetKeyDown("space") && !inAir)
            {
                Vector3 jump = new Vector3(0f, 300.0f, 0f);
                player.AddForce(jump);
            }

            if (Input.GetKeyDown("escape"))
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!frozen)
        {
            //For moving the player around
            float moveHorizontal = Input.GetAxis("Horizontal") * speed;
            float moveVertical = Input.GetAxis("Vertical") * speed;

            moveHorizontal *= Time.deltaTime;
            moveVertical *= Time.deltaTime;

            if((moveVertical != 0.0f || moveHorizontal != 0.0f) && grounded && !playing)
            {
                StartCoroutine(Footsteps());
            }

            transform.Translate(moveHorizontal, 0, moveVertical); // Reddit says to use  rigidbody.MovePosition() and rigidbody.MoveRotation()
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
            inAir = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            inAir = false;
        }
        if (collision.gameObject.CompareTag("Death"))
        {
            grounded = true;
            inAir = false;
            death();
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            checkpoint = collision.gameObject;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            checkpoint = other.gameObject;
        }

    }
    public void death()
    {
        if (heldCube.GetComponent<Pickup>().holding)
        {
            heldCube.GetComponent<Pickup>().Drop();
        }
        player.gameObject.GetComponent<GrapplingHook>().ReturnHook();
        player.gameObject.SetActive(false);
        player.gameObject.transform.position = checkpoint.transform.position;
        player.gameObject.SetActive(true);
    }

    IEnumerator Footsteps()
    {
        playing = true;
        FootstepAudio.volume = Random.Range(0.8f, 1.0f);
        FootstepAudio.pitch = Random.Range(0.5f, 0.6f);
        FootstepAudio.clip = FootstepClip;
        FootstepAudio.Play();
        yield return new WaitForSeconds(0.4f);
        playing = false;
    }
}
