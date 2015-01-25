using UnityEngine;
using System.Collections;

public class OvaScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		Collider2D colliderX = coll.collider;
		if (colliderX.tag == "Player" ) 
		{
			Application.LoadLevel("Finished");
		}
	}
}
