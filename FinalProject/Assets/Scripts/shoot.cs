using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private bool playerInRange;
    private GameObject player;
    private int index;
    private MeshRenderer[] children;

    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //this.gameObject.transform.GetChild(0).gameObject.GetComponent<Fire>().enabled = false;
        //var children = new ArrayList();
        children = GetComponentsInChildren<MeshRenderer>();
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, radius);
        //int i = 0;
        //while(i < hitColliders.Length)
        //{
        //    if(hitColliders[i].name == "Player")
        //    {
        //        if (Input.GetKeyDown("e"))
        //        {
        //            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Fire>().enabled = true;
        //        }
        //    }
        //    i++;
        //}

        if(playerInRange && Input.GetKeyDown("e"))
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<LineRenderer>().enabled = true;
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Fire>().enabled = true;
            for (index = 1; index < children.Length; index++)
            {
                children[index].enabled = true;
            }
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
        if (other.name == "Player")
        {
            playerInRange = false;
        }
    }
}
