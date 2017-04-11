using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Injurer : MonoBehaviour
{
    public int Damage;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    private void OnTriggerEnter(Collider other)
    {
        var life = other.gameObject.GetComponent<Life>();
        if(life == null)
        {
            return;
        }

        life.Injure(Damage);
    }
}
