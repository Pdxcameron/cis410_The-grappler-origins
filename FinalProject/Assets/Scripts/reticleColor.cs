using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reticleColor : MonoBehaviour
{
    RawImage m_RawImage;
    private Color m_Color;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        m_RawImage = GetComponent<RawImage>();
        //m_Color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        //m_RawImage.color = m_Color;
    }
}
