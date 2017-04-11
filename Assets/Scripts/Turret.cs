using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    /// <summary>
    /// The objet the turret tries to aim
    /// </summary>
    public Transform Target;

    /// <summary>
    /// The rotation speed of the turret
    /// </summary>
    public float RotationSpeed;



    // Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        var targetRotation = Quaternion.LookRotation((Target.position - transform.position).normalized);
        var angle = targetRotation.eulerAngles.y - transform.rotation.eulerAngles.y;

        if(Mathf.Abs(angle) > 180f)
        {
            angle += 360f * (angle > 0f ? -1f : 1f);
        }

        angle = Mathf.Min(Mathf.Abs(angle), RotationSpeed * Time.deltaTime) * (angle < 0f ? -1f : 1f);

        transform.Rotate(Vector3.up, angle);
    }

    void OnDestroy()
    {
        Feedback.Instance.ShowMessage("Congratulations. Now the door is open.", 3f);
    }
}
