using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public GameObject Bullet;

    /// <summary>
    /// 
    /// </summary>
    public float BulletsPerSecond;

    /// <summary>
    /// 
    /// </summary>
    private float elapsedTime;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > (1f / BulletsPerSecond))
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            elapsedTime %= (1f / BulletsPerSecond);
        }
	}
}
