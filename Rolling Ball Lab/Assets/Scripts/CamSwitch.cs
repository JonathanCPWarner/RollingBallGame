using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{

    public GameObject cameraZoomedOut; //CameraZoomedOut = "CameraTarget"
    public GameObject cameraZoomedIn; //CameraZoomedIn = "CameraFollowPlayer"

    private bool cameraSwitch = false; //Boolean to determine which camera is active

    private void Update()
    {
        if (Input.GetKeyDown("Q"))
        { 

            cameraSwitch = !cameraSwitch;
        } 

        if (cameraSwitch == true)
        {
            cameraZoomedOut.SetActive(false);
            cameraZoomedIn.SetActive(true);
        }

        if (cameraSwitch == false)
        {
            cameraZoomedOut.SetActive(true);
            cameraZoomedIn.SetActive(false);
        }
    }

    
}
