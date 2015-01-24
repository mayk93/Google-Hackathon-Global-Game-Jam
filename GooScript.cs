using UnityEngine;
using System.Collections;

public class GooScript : MonoBehaviour {

	public GameObject sperm;
	public GameObject empty;
	public Sprite [] gooArray;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (sperm.rigidbody2D.position.x + Random.Range (-1f, 1f), sperm.rigidbody2D.position.y + 10);
		InvokeRepeating ("spawnGoo", 0.3f , 0.3f);
	}

	void spawnGoo()
	{
		//gooArray [Random.Range (0, gooArray.Length - 1)]
		GameObject clone = (GameObject)Instantiate (empty, new Vector3(transform.position.x,transform.position.y,transform.position.z-1), Quaternion.identity);
		SpriteRenderer cloneSpriteRenderer = clone.AddComponent<SpriteRenderer>();
		cloneSpriteRenderer.sprite = gooArray [Random.Range (0, gooArray.Length - 1)];
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (sperm.rigidbody2D.position.x + Random.Range (-1f, 1f), sperm.rigidbody2D.position.y + 10);
	}
}
