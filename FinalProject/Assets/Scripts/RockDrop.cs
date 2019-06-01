using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDrop : MonoBehaviour
{
    public float smooth = 1.0f;

    public void dropRock()
    {
        StartCoroutine(pivot());
    }

    public void stopRock()
    {
        StopAllCoroutines();
    }

    IEnumerator pivot()
    {
        while (true)
        {
            if (this.transform.rotation != Quaternion.identity)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 10 * smooth * Time.deltaTime);
            }
            yield return null;
        }
    }
}
