using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDropper : MonoBehaviour
{
    public float smooth = 1.0f;

    public void dropGate()
    {
        StartCoroutine(pivot());
    }

    public void stopGate()
    {
        StopAllCoroutines();
    }

    IEnumerator pivot()
    {
        while (true)
        {
            if(this.transform.rotation != Quaternion.identity)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 10 * smooth * Time.deltaTime);
            }
            yield return null;
        }
    }
}
