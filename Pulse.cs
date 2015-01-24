using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {

	public Sprite [] gooArrayX;
	public SpriteRenderer sprRend;
	// Use this for initialization
	void Start () {
		gooArrayX = FindObjectOfType<GooScript>().gooArray;
		sprRend = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		print (1);
		sprRend.sprite = gooArrayX [1];

		//Random.Range (0, gooArrayX.Length - 1)
	}
}
