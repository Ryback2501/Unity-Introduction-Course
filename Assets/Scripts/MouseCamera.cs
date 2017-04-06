using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private float[] mouseDelta = new float[2];

    /// <summary>
    /// A reference to the Transform component of the player's camera
    /// </summary>
    public Transform PlayerCamera;

    /// <summary>
    /// The sensitivity to the horizontal movement of the mouse
    /// </summary>
    public float HorizontelSensitivity;

    /// <summary>
    /// The sensitivity to the vertical movement of the mouse
    /// </summary>
    public float VerticalSensitivity;

    /// <summary>
    /// The maximum angle deviation from horizontal
    /// </summary>
    [Range(0, 90)]
    public float MaxVerticalDev;

    public Vector3 Forward;
    
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Get mouse movement
        mouseDelta[0] = Input.GetAxis("Mouse X");
        mouseDelta[1] = Input.GetAxis("Mouse Y");

        //Apply rotation
        transform.Rotate(Vector3.up * mouseDelta[0] * HorizontelSensitivity);
        PlayerCamera.Rotate(Vector3.left * mouseDelta[1] * VerticalSensitivity);

        //Fix vertical rotation
        PlayerCamera.localRotation = FixVerticalRotation(PlayerCamera.localRotation);

        Forward = PlayerCamera.localRotation.eulerAngles;
    }

    /// <summary>
    /// Fixes vertical rotation
    /// </summary>
    /// <param name="rotation"></param>
    /// <returns></returns>
    private Quaternion FixVerticalRotation(Quaternion rotation)
    {
        //Rotation is vertical

        var euler = Vector3.right * rotation.eulerAngles.x;

        //Change the angle to simplify calculations
        euler.x += 180;
        euler.x %= 360;

        //Keep the vertical angle inside the valid range
        euler.x = Mathf.Max(Mathf.Min(euler.x, 180 + MaxVerticalDev), 180 - MaxVerticalDev);

        //Fix the angle
        euler.x += 180;
        euler.x %= 360;

        return Quaternion.Euler(euler);
    }
}
