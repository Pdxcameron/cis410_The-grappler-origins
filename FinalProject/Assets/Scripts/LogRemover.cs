using UnityEngine;

public class LogRemover : MonoBehaviour
{
    public GameObject prev;

    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.name == "wood-axe")
        {
            if (!prev.activeSelf)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}