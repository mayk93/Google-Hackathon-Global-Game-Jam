using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public ParticleSystem explosion;

	// Use this for initialization
	void Start () {
	
	}

	void OnDestroy() 
	{
		ParticleSystem p = (ParticleSystem)Instantiate(explosion, transform.position, transform.rotation);
		Destroy (p , 0.5f);
	}

	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 3);
	}

	void OnCollisionEnter2D()
	{
		Destroy (gameObject);
	}
}
