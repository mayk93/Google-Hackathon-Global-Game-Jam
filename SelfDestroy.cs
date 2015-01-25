using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public ParticleSystem explosion;
	private AudioClip [] destruction;
	private AudioSource destructionAudioSource;

	// Use this for initialization
	void Start () {
		//Destroy (gameObject, 3f);
		destructionAudioSource = gameObject.AddComponent<AudioSource>();
		destruction = GameObject.Find ("GUI_Manager").GetComponent<GUI_Script> ().destructionArray;
	}

	void BeforeDestroy (GameObject gameObject)
	{
		destructionAudioSource = gameObject.AddComponent<AudioSource>();

		audio.clip = destruction [Random.Range (0, destruction.Length - 1)];
		audio.Play ();

		ParticleSystem p = (ParticleSystem)Instantiate(explosion, transform.position, transform.rotation);
		Destroy (gameObject, 3f);
		//Destroy (p , 0.5f);
	}

	void BeforeDestroyQuick (GameObject gameObject)
	{
		destructionAudioSource = gameObject.AddComponent<AudioSource>();

		audio.clip = destruction [Random.Range (0, destruction.Length - 1)];
		audio.Play ();

		ParticleSystem p = (ParticleSystem)Instantiate(explosion, transform.position, transform.rotation);
		Destroy (gameObject, 0.1f);
			//Destroy (p , 0.5f);
	}

	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (transform.localScale.x + 0.001f, transform.localScale.y + 0.001f, transform.localScale.z + 0.01f);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		Collider2D colliderX = coll.collider;
		if (colliderX.tag == "Player" ) 
		{
			coll.gameObject.GetComponent<Health>().takeDamage(Random.Range(10f,20f));
			BeforeDestroyQuick (gameObject);
		}
		if (colliderX.tag == "Projectile") 
		{
			//print ("Projectile Collision");
			BeforeDestroyQuick (gameObject);
		}
	}
}
