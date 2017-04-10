using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// The speed the bullet moves at
    /// </summary>
    public float Speed;

    /// <summary>
    /// The maximum tyime the bullet can exist
    /// </summary>
    public float LifeTime;

    /// <summary>
    /// If TRUE, the bullet bounces with the surface it touches, otherwise, it it destroyed
    /// </summary>
    public bool Bounce;

    /// <summary>
    /// The elapsed ime since the bullet was created
    /// </summary>
    private float elapsedTime;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * Speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > LifeTime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(!Bounce)
        {
            Destroy(gameObject);
        }
    }
}
