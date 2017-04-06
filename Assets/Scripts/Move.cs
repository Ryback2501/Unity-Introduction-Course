using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    /// <summary>
    /// The speed the avatar moves at
    /// </summary>
    public float Speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position +=
              transform.TransformDirection(Vector3.forward) * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position +=
              transform.TransformDirection(Vector3.left) * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position +=
              transform.TransformDirection(Vector3.back) * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position +=
              transform.TransformDirection(Vector3.right) * Time.deltaTime * Speed;
        }
    }
}
