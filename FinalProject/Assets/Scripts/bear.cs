using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bear : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().heldCube.GetComponent<Pickup>().Drop();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerControls>().death();
        }
    }
}
