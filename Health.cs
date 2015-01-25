﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100f;
	private SpermMovement movement;
	public GameObject sperm;
	private bool isDead;

	public AudioClip deathSound;

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

	IEnumerator spermDying()
	{
		audio.PlayOneShot (deathSound, 1);
		isDead = true;

		yield return new WaitForSeconds (3);

		Application.LoadLevel ("gameOver");
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
