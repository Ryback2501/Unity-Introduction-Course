using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float Reach;

    public Transform Camera;

    private bool showing;

    private RaycastHit hitInfo;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out hitInfo, Reach))
        {
            var knob = hitInfo.transform.GetComponent<Knob>();
            if (knob == null)
            {
                HideFeedbackMessage();
                return;
            }

            ShowFeedbackMessage();

            if (Input.GetKey(KeyCode.F))
            {
                knob.Open();
            }
        }
        else
        {
            HideFeedbackMessage();
        }
	}

    /// <summary>
    /// Shows the feedback message
    /// </summary>
    private void ShowFeedbackMessage()
    {
        if (!showing)
        {
            showing = true;
            Feedback.Instance.ShowMessage("Press F to open Door.");
        }
    }

    /// <summary>
    /// Hides the feedback message
    /// </summary>
    private void HideFeedbackMessage()
    {
        if (showing)
        {
            showing = false;
            Feedback.Instance.HideMessage();
        }
    }
}
