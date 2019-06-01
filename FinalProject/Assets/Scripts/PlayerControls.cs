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

    public GameObject checkpoint;
    private Rigidbody player;
    private bool grounded; // IS THIS VALUE USED IN OTHER SCRIPTS? ITS VALUE ISNT ACTUALLY USED FOR ANYTHING IN THIS ONE
    private bool inAir;
    public bool frozen;

    // Start is called before the first frame update
    void Start()
    {
        ConstantAudio.loop = true;

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
}
