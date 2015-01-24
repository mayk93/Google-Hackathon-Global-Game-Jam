using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public ParticleSystem explosion;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3f);
	}

	void BeforeDestroy (GameObject gameObject)
	{
		ParticleSystem p = (ParticleSystem)Instantiate(explosion, transform.position, transform.rotation);
		Destroy (gameObject, 3f);
		//Destroy (p , 0.5f);
	}

	void BeforeDestroyQuick (GameObject gameObject)
	{
		ParticleSystem p = (ParticleSystem)Instantiate(explosion, transform.position, transform.rotation);
		Destroy (gameObject, 1f);
			//Destroy (p , 0.5f);
	}

	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (transform.localScale.x + 0.01f, transform.localScale.y + 0.01f, transform.localScale.z + 0.01f);
	}

	void OnCollisionEnter2D()
	{
		BeforeDestroyQuick (gameObject);
	}
}
