using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {

	public Sprite [] gooArrayX;
	public SpriteRenderer sprRend;

	int start = 0;

	// Use this for initialization
	void Start () {
		gooArrayX = FindObjectOfType<GooScript>().gooArray;
		sprRend = gameObject.GetComponent<SpriteRenderer>();

		InvokeRepeating ("AnimateCells", 0.3f , 0.3f);
	}

	void AnimateCells()
	{
		sprRend.sprite = gooArrayX [start%2];
		
		start = start + 1;
		
		if ( start == 100 )
		{
			start = 0;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		//Random.Range (0, gooArrayX.Length - 1)
	}
}
