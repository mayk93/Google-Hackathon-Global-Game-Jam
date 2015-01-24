using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public ParticleSystem explosion;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3);
	}

	void OnDestroy() 
	{
		ParticleSystem p = (ParticleSystem)Instantiate(explosion, transform.position, transform.rotation);
		Destroy (p , 0.5f);
	}

	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f);
	}

	void OnCollisionEnter2D()
	{
		Destroy (gameObject);
	}
}
