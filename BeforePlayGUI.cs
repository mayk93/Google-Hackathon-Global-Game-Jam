using UnityEngine;
using System.Collections;

public class BeforePlayGUI : MonoBehaviour {

	public GameObject textSprite;
	public Sprite nextSprite;

	private SpriteRenderer mySpr;

	public GameObject buttonStart;

	// Use this for initialization
	void Start () {
		mySpr = textSprite.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Next ()
	{
		mySpr.sprite = nextSprite;
		buttonStart.SetActive (true);
	}

	public void StartButtonFunction()
	{
		Application.LoadLevel ("test");
	}
}
