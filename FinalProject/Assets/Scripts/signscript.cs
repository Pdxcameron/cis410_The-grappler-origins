using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signscript : MonoBehaviour
{
    public float sphereRadius;
    public Text wintext;
    public string hint; 
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    { 
        wintext.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - this.transform.position).sqrMagnitude < 3 * 3)
        {
            wintext.text = hint;
        }
        else 
        {
            wintext.text = "";
        }
    }
}
