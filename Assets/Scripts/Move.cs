using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    /// <summary>
    /// Reference to the rigidbody of the player.
    /// </summary>
    public Rigidbody MyRigidbody;

    /// <summary>
    /// The acceleration of the movement.
    /// </summary>
    public float Acceleration;

    /// <summary>
    /// The initial vertical velocity of the jump.
    /// </summary>
    public float JumpStartVelocity;

    /// <summary>
    /// The speed the avatar moves at.
    /// </summary>
    public float MaxSpeed;

    /// <summary>
    /// The maximum inclination of a surface to consider it ground.
    /// </summary>
    public float MaxSlope;

    /// <summary>
    /// If TRUE, the player is in contact with the ground.
    /// </summary>
    private bool grounded;

    /// <summary>
    /// If TRUE, the player already preformed a double jump.
    /// </summary>
    private bool doubleJumped;
	
	// Update is called once per frame
	void Update ()
    {
        if (grounded && MyRigidbody.velocity.magnitude < MaxSpeed)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                MyRigidbody.AddRelativeForce(Vector3.forward * Acceleration);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                MyRigidbody.AddRelativeForce(Vector3.left * Acceleration);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                MyRigidbody.AddRelativeForce(Vector3.back * Acceleration);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                MyRigidbody.AddRelativeForce(Vector3.right * Acceleration);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded || !doubleJumped)
            {
                doubleJumped = !grounded;

                var velocity = MyRigidbody.velocity;
                velocity.y = JumpStartVelocity;
                MyRigidbody.velocity = velocity;
            }
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        foreach (var contact in collisionInfo.contacts)
        {
            if (Vector3.Angle(contact.normal, Vector3.up) < MaxSlope)
            {
                grounded = true;
                return;
            }
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        grounded = false;
    }
}
