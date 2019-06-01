// https://gamedev.stackexchange.com/questions/96878/how-to-animate-objects-with-bobbing-up-and-down-motion-in-unity
using UnityEngine;
using System;

public class bounce : MonoBehaviour
{
    float originalY;
    public float floatStrength = 1;
    public float speed = 2.0f;

    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, originalY + ((float)Math.Sin(Time.time*speed) * floatStrength), transform.position.z);
    }
}