using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feedback : MonoBehaviour
{
    #region Singleton

    public static Feedback Instance
    {
        get { return instance; }
    }

    private static Feedback instance;

    #endregion

    /// <summary>
    /// Reference to the Text component.
    /// </summary>
    private Text text;

    /// <summary>
    /// The time the message will be visible.
    /// </summary>
    private float messageTime;

    /// <summary>
    /// The time the message has been visible since showed.
    /// </summary>
    private float elapsedTime;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        text = GetComponent<Text>();
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (messageTime == 0 || text.text.Equals(string.Empty))
        {
            return;
        }

        elapsedTime += Time.deltaTime;
        if(elapsedTime > messageTime)
        {
            text.text = string.Empty;
        }
	}

    /// <summary>
    /// Shows a feedback message.
    /// </summary>
    /// <param name="message">The text of the message.</param>
    /// <param name="time">The time the message is visible. If zero, the message doesn't automatically hide.</param>
    public void ShowMessage(string message, float time = 0f)
    {
        text.text = message;
        messageTime = time;
        elapsedTime = 0f;
    }

    /// <summary>
    /// Hides the feedback message.
    /// </summary>
    public void HideMessage()
    {
        if(messageTime == 0f)
        {
            text.text = string.Empty;
        }
    }
}
