using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    private Vector2 cam;
    private Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject character;


    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;


    }

    // Update is called once per frame
    void Update()
    {
        var camchange = new Vector2 (Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        camchange = Vector2.Scale(camchange, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, camchange.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, camchange.y, 1f / smoothing);
        cam += smoothV;


        transform.localRotation = Quaternion.AngleAxis(-cam.y, Vector3.right);

        this.transform.localRotation = Quaternion.AngleAxis(cam.x, character.transform.up);
    }
}
