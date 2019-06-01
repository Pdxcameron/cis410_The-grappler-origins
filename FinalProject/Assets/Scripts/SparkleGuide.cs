using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleGuide : MonoBehaviour
{
    public ParticleSystem prev;
    public ParticleSystem thisOne;

    private void Start()
    {
        if(prev)
        {
            thisOne.Stop();
            thisOne.Clear();
        }
    }

    void Update()
    {
        if (prev)
        {
            if (!prev.gameObject.activeSelf)
            {
                thisOne.Emit(35);
                thisOne.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && thisOne.isPlaying)
        {
            this.gameObject.SetActive(false);
        }
    }
}
