using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100f;
	private SpermMovement movement;
	public GameObject sperm;
	private bool isDead;

	// Use this for initialization
	void Start () {
		movement = GetComponent<SpermMovement> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health <= 0) 
		{
			if(isDead == false)
			{
				spermDying();
			}
			else
			{
				spermDead();
			}
		}
		else
		{

		}
	}

	void spermDying()
	{
		isDead = true;
	}

	void spermDead()
	{
		movement.enabled = false;
		sperm.rigidbody2D.gravityScale = 10f;
	}

	public void takeDamage(float damage)
	{
		health = health - damage;
	}
}
