using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed;


    private Rigidbody player;
    private bool grounded;
    private bool inAir;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();

        //For First person camera handling
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && inAir == false)
        {
            Debug.Log("jumping");
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

        transform.Translate(moveHorizontal, 0, moveVertical);

        //Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        //player.position += (movement * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            inAir = false;
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
}
