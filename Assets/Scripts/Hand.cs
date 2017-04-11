using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float Reach;

    public Transform Camera;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.F))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.position, Camera.forward, out hitInfo, Reach))
            {
                var knob = hitInfo.transform.GetComponent<Knob>();
                if(knob == null)
                {
                    return;
                }
                knob.Open();
            }
        }
	}
}
