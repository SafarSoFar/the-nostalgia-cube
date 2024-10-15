using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StensilCameraMovement : MonoBehaviour
{
    Camera mainCamera;
    Vector3 origPosition;
    Vector3 origEuler;
    // Start is called before the first frame update
    void Start()
    {
      mainCamera = Camera.main;
      origPosition = transform.position;
      origEuler = transform.eulerAngles;  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = origPosition + mainCamera.transform.position;
        transform.eulerAngles = origEuler + mainCamera.transform.eulerAngles;
    }
}
