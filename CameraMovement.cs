using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Works by draging on the main camera
public class CameraMovement : MonoBehaviour
{
    [SerializeField] float sensX;
    [SerializeField] float sensY;
    [SerializeField] Transform orientation;
    // Start is called before the first frame update

    float xRotation, yRotation;

    [SerializeField] float smoothness = 3.0f;
    float timeCount = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        sensX *= 15f;
        sensY *= 15f;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.J)){
        //     this.transform.eulerAngles += Vector3.left * sensX;
        // }
        // else if(Input.GetKeyDown(KeyCode.L)){
        //     this.transform.eulerAngles += Vector3.right * sensX;
        // }

        Rotate();
    }

    void Rotate(){
        float xVal;
        float yVal;
        xVal = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        yVal = Input.GetAxis("Mouse Y")  * Time.deltaTime * sensY;


        yRotation += xVal;
        xRotation -= yVal;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(xRotation,yRotation,0f), smoothness*timeCount);
        orientation.rotation =  Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0f,yRotation,0f), smoothness*timeCount);
        timeCount += Time.deltaTime;

    }
}
