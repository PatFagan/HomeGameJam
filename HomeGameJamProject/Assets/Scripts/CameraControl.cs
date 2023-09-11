using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraControl : MonoBehaviour
{
    public GameObject cam;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(slider.value, -2, -10);
    }
}