using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour
{
    public GameObject Turret;

    private Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Open()
    {
        if(Turret == null)
        {
            animator.SetTrigger("Open");
        }
        else
        {
            Feedback.Instance.ShowMessage("You must defeat the turret first.", 3f);
        }
    }
}
