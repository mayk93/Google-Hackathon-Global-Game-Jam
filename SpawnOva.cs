using UnityEngine;
using System.Collections;

public class SpawnOva : MonoBehaviour {

	public GameObject sperm;
	public Sprite ova;

	public GameObject empty;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (sperm.rigidbody2D.position.x, sperm.rigidbody2D.position.y + 20);
		InvokeRepeating ("SpawnOvaFunction", 5f , 5f);
		//CallSpawnOvaFunction ();
	}
	/*	
	void CallSpawnOvaFunction()
	{
		print ("01");
		SpawnOvaFunction ();
		print ("02");
	}
	*/
	void SpawnOvaFunction()
	{
		//print (1);
		//yield return new WaitForSeconds (5f);
		//print (2);
		GameObject ovaX = (GameObject)Instantiate (empty, new Vector3(transform.position.x ,transform.position.y + 5f,transform.position.z-1), Quaternion.identity);
		SpriteRenderer ovaXR = ovaX.AddComponent<SpriteRenderer>();
		ovaXR.sprite = ova;
		Rigidbody2D ovaRidgidBody2D = ovaX.AddComponent<Rigidbody2D> ();
		ovaRidgidBody2D.gravityScale = 0.1f;
		PolygonCollider2D ovaPolygonCollider2D = ovaX.AddComponent<PolygonCollider2D> ();
		OvaScript ovaXScript = ovaX.AddComponent<OvaScript> ();
	}

	void Update () {
		transform.position = new Vector2 (sperm.rigidbody2D.position.x, sperm.rigidbody2D.position.y + 10);
	}
}
