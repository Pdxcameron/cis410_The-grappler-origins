using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchScript : MonoBehaviour
{
    public GameObject bridge;
    public float sphereRadius;
    public Text wintext;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (bridge == null)
            bridge = GameObject.Find("Bridge");
        if (bridge.activeSelf)
            bridge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphereRadius);
        if ((player.transform.position - this.transform.position).sqrMagnitude < 3 * 3)
        {
            wintext.text = "press 'e' to interact";

            if (Input.GetKeyDown("e"))
            {
                if (bridge.activeSelf)
                {
                    bridge.SetActive(false);
                    GetComponent<Renderer>().material.color = Color.red;
                }
                else
                {
                    bridge.SetActive(true);
                    GetComponent<Renderer>().material.color = Color.green;
                }
            }
        }
        else
        {
            wintext.text = "";
        }
    }
}
