using UnityEngine;
using System.Collections;

public class GooScript : MonoBehaviour {

	public GameObject sperm;
	public GameObject empty;
	public Sprite [] gooArray;
	public ParticleSystem explosionEffect;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (sperm.rigidbody2D.position.x, sperm.rigidbody2D.position.y + 15);
		InvokeRepeating ("spawnGoo", 2f , 2f);
	}

	void spawnGoo()
	{
		//gooArray [Random.Range (0, gooArray.Length - 1)]
		GameObject clone = (GameObject)Instantiate (empty, new Vector3(transform.position.x + Random.Range (-10f, 10f),transform.position.y + Random.Range (0f, 1f),transform.position.z-1), Quaternion.identity);
		SpriteRenderer cloneSpriteRenderer = clone.AddComponent<SpriteRenderer>();
		cloneSpriteRenderer.sprite = gooArray [Random.Range (0, gooArray.Length - 1)];
		Rigidbody2D cloneRidgidBody2D = clone.AddComponent<Rigidbody2D> ();
		cloneRidgidBody2D.gravityScale = 0.3f;
		PolygonCollider2D clonePolygonCollider2D = clone.AddComponent<PolygonCollider2D> ();
		SelfDestroy cloneSelfDestroy = clone.AddComponent<SelfDestroy> ();
		cloneSelfDestroy.explosion = explosionEffect;

		clone.transform.localScale = new Vector3 (Random.Range (1f, 3f), Random.Range (1f, 3f), Random.Range (0.5f, 1.5f));
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (sperm.rigidbody2D.position.x, sperm.rigidbody2D.position.y + 10);
	}
}
