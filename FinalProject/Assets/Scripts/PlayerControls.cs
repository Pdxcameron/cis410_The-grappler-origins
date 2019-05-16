using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed;

    public GameObject checkpoint;
    private Rigidbody player;
    private bool grounded;
    private bool inAir;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();

        checkpoint = GameObject.Find("start_checkpoint");
        //For First person camera handling
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
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

    private void FixedUpdate()
    {
        //For moving the player around
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        moveHorizontal *= Time.deltaTime;
        moveVertical *= Time.deltaTime;

        transform.Translate(moveHorizontal, 0, moveVertical); // Reddit says to use  rigidbody.MovePosition() and rigidbody.MoveRotation()
    }

    void OnCollisionEnter(Collision collision)
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

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
            inAir = true;
        }
    }

    private void death()
    {
        player.gameObject.SetActive(false);
        player.gameObject.transform.position = checkpoint.transform.position;
        player.gameObject.SetActive(true);
    }
}
