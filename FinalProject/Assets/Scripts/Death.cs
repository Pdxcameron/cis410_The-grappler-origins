using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Vector3 homeBase;

    // Start is called before the first frame update
    void Start()
    {
        homeBase = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            this.gameObject.GetComponent<Pickup>().Drop();
            this.gameObject.SetActive(false);
            this.transform.position = homeBase;
            this.gameObject.SetActive(true);
        }
    }
}
