using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotGate : MonoBehaviour
{
    private Transform pivot;
    public float smooth = 1.0f;

    void Start()
    {
        pivot = this.gameObject.transform.parent;
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 5);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].name == "Player")
            {
                if (Input.GetKeyDown("e"))
                {
                    openGate();
                    break;
                }
            }
            i++;
        }
    }

    public void openGate()
    {
        StartCoroutine(piv());
    }

    public void stopGate()
    {
        StopAllCoroutines();
    }

    IEnumerator piv()
    {
        while (true)
        {
            if (pivot.transform.rotation != Quaternion.identity)
            {
                pivot.rotation = Quaternion.Lerp(pivot.rotation, Quaternion.identity, 10 * smooth * Time.deltaTime);
            }
            yield return null;
        }
    }
}
