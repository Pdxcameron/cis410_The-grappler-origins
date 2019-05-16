using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    public GameObject toggle;
    public bool inverse = false;
    public float speed = 1.0f;
    public float drop = -0.15f;
    private List<GameObject> currentCollisions = new List<GameObject>();
    private Vector3 downPosition;
    private Vector3 upPosition;
    private bool needsMovingUp = false;
    private bool needsMovingDown = false;

    void Start()
    {
        upPosition = transform.position;
        Vector3 temp = new Vector3(0, drop, 0);
        downPosition = upPosition + temp;
    }

    // Update is called once per frame
    void Update()
    {
        //float step = speed * Time.deltaTime;
        //if (needsMovingUp)
        //{
        //    Debug.Log("Moving up");
        //    transform.position = Vector3.MoveTowards(transform.position, upPosition, step);
        //}
        //if (needsMovingDown)
        //{
        //    Debug.Log("Moving down");
        //    transform.position = Vector3.MoveTowards(transform.position, downPosition, step);
        //}
        //if (transform.position == upPosition)
        //{
        //    //Debug.Log("Done moving up");
        //    needsMovingUp = false;
        //}
        //if (transform.position == downPosition)
        //{
        //    //Debug.Log("Done moving down");
        //    needsMovingDown = false;
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Grabbable"))
        {  
            if (!currentCollisions.Contains(other.gameObject))
            {
                currentCollisions.Add(other.gameObject);
            }
            //Debug.Log("Plate needs moving down");
            //needsMovingDown = true;
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
                //Debug.Log("Plate needs moving up");
                //needsMovingUp = true;
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
