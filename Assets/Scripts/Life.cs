using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    /// <summary>
    /// Maximum life points
    /// </summary>
    public int MaxLifePoints;

    /// <summary>
    /// The current Life Points
    /// </summary>
    private int lifePoints;

    void Awake()
    {
        lifePoints = MaxLifePoints;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Heal(int healedPoints)
    {
        lifePoints = Mathf.Min(MaxLifePoints, lifePoints + healedPoints);
    }

    public void Injure(int damage)
    {
        lifePoints = Mathf.Max(0, lifePoints - damage);
        if(lifePoints == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if(GetComponent<Move>() != null)
        {
            //TODO: Go to GAME OVER
        }
        Destroy(gameObject);
    }
}
