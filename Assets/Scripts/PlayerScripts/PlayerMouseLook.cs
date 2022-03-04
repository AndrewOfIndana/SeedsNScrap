using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    private bool isCameraOn = true;
    RaycastHit hit;
    public GameObject Tools;
    private bool isGrabbed = false;
    private float plantTime = 5;
    private GameObject grabbedObject;
    public Transform grabPosition;

    void Awake()
    {
        grabbedObject = null;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if (isCameraOn == true)
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

        //Pick up items

        Ray r = new Ray(transform.position, transform.forward);
        RaycastHit hit;
    
        if (Input.GetMouseButtonDown(1) && Physics.Raycast(r, out hit, 5) && isGrabbed == false)
        {
            if( hit.collider.CompareTag("_Item"))
            {
                grabbedObject = hit.transform.gameObject;
                grabbedObject.SendMessage("Grabbed");
                grabbedObject.transform.SetParent(grabPosition.transform, true);
                Tools.SetActive(false);
                isGrabbed = true;
            }
        }
        else if(Input.GetMouseButtonDown(0) && isGrabbed == true)
        {
            grabbedObject.transform.SetParent(null, true);
            grabbedObject.SendMessage("Dropped");
            grabbedObject = null;
            Tools.SetActive(true);
            isGrabbed = false;
        }

        if (grabbedObject)
        {
            if(Input.GetMouseButton(1))
            {
                plantTime -= Time.deltaTime;
                if(plantTime <= 0)
                {
                    plantTime = 5;
                    grabbedObject.SendMessage("Plant");
                    grabbedObject = null;
                    Tools.SetActive(true);
                    isGrabbed = false;
                }
            }
            else
            {
                plantTime = 5;
            }
        }
    }

    public void CameraPause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isCameraOn = false;
    }
    
    public void CameraResume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isCameraOn = true;
    }
}
