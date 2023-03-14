using UnityEngine;

/// <summary>
/// Small C# script to quickly recenter player now that Meta (Oculus) decided to deprecate that feature. Use for Unity VR projects.
/// 
/// Variables
/// 1) vrCamera is the VR camera transform
/// 2) vrCameraRoot is the root of the camera transform. We move & rotate this transform because VR cameras cannot be adjusted directly
/// 3) resetTransform is the desired position & rotation(look direction) for your player. Place this transform wherever that may be in your scene.
///
/// Based on Justin P Barnett's YouTube video: https://youtu.be/EmjBonbATS0
/// </summary>

public class Recenter : MonoBehaviour
{
    public Transform vrCamera; // The VR camera transform
    public Transform vrCameraRoot; // The root of the camera transform
    public Transform resetTransform; // The desired position & rotation (look direction) for your player

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RecenterPlayer();
        }
    }

    void RecenterPlayer()
    { 
        float rotationAngleY = vrCamera.rotation.eulerAngles.y - resetTransform.rotation.eulerAngles.y;

        vrCameraRoot.transform.Rotate(0, -rotationAngleY, 0);

        Vector3 distanceDiff = resetTransform.position - vrCamera.position;
        vrCameraRoot.transform.position += distanceDiff;

    }
}
