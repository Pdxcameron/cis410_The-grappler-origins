using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_fire : MonoBehaviour
{
    public GameObject ball;
    public ParticleSystem particle;
    public GameObject target;
    public ParticleSystem boom;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if((ball != null) && (ball.transform.position - this.transform.position).sqrMagnitude < 3 * 3)
        {
            Destroy(ball);
            particle.Play(true);
            Destroy(target);
            boom.Play(true);



        }
    }
}
