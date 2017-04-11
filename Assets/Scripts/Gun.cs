using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public Camera PlayerCamera;

    /// <summary>
    /// 
    /// </summary>
    public GameObject Bullet;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet,
                        PlayerCamera.transform.position,
                        PlayerCamera.transform.rotation);
        }
	}
}
