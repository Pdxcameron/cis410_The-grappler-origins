using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchCheck : MonoBehaviour
{
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
        if (other.name == "torche")
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
