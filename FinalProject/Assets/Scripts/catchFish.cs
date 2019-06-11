using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchFish : MonoBehaviour
{
    public GameObject fishSpawn;

    private GameObject fish;
    // Start is called before the first frame update
    void Start()
    {
        fish = GameObject.FindGameObjectWithTag("Fish");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "fishline")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().heldCube.GetComponent<Pickup>().Drop();
            Destroy(GameObject.FindGameObjectWithTag("FishPole"));
            fish.transform.localScale = new Vector3(1f, 1f, 1f);
            fish.transform.position = fishSpawn.transform.position;
            fish.GetComponent<Death>().enabled = true;
        }
    }
}
