using UnityEngine;
using System.Collections;

public class GoToMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goTo()
	{
		Application.LoadLevel("entry");
	}
}
