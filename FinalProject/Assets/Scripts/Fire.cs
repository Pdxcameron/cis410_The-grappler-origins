using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private LineRenderer line;
    private float counter;
    private float dist;

    public Transform origin;
    public Transform anchor;

    public float lineSpeed = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.SetPosition(0, origin.position);

        dist = Vector3.Distance(origin.position, anchor.position);
    }

    // Update is called once per frame
    void Update()
    {
        while (counter < dist)
        {
            counter += .1f / lineSpeed;

            float x = Mathf.Lerp(0, dist, counter);

            Vector3 begin = origin.position;
            Vector3 end = anchor.position;

            Vector3 pointAlongLine = x * Vector3.Normalize(end - begin) + begin;

            line.SetPosition(1, pointAlongLine);
        }
    }
}
