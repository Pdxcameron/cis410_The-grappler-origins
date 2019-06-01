using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camMouseLook : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    //For reticle color changing
    Camera CameraToCastFrom;
    public RawImage reticle;
    RaycastHit hitInfo;

    GameObject player;

    Color Hovered = Color.green;
    Color UnHovered = new Color(251, 251, 251, 140);

    void changeColor()
    {
        reticle.color = Hovered;
    }

    void resetColor()
    {
        reticle.color = UnHovered;
    }
    // Start is called before the first frame update
    void Start()
    {
        CameraToCastFrom = GetComponent<Camera>();
        player = this.transform.parent.gameObject;
        //player.transform.SetPositionAndRotation(player.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<PlayerControls>().frozen)
        {
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxis("Mouse Y"));

            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
            mouseLook += smoothV;

            transform.localRotation = Quaternion.AngleAxis(Mathf.Clamp(-mouseLook.y, -90f, 80f), Vector3.right);
            //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);

            //Raycast for detecting objects to decide whether or not to change color
            Ray rayToCast = CameraToCastFrom.ScreenPointToRay(reticle.transform.position);
            if (Physics.Raycast(rayToCast, out hitInfo, 20f) &&
            (hitInfo.collider.gameObject.CompareTag("Grabbable") || hitInfo.collider.gameObject.CompareTag("Hookable")))
            {
                changeColor();
            }
            else
            {
                resetColor();
            }
        }
    }
}
