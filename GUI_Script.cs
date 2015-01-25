using UnityEngine;
using System.Collections;

public class GUI_Script : MonoBehaviour {

	public GameObject sperm;
	public AudioClip [] destructionArray;

	private Health hpScript;
	public Texture [] healthArray;

	// Use this for initialization
	void Start () {
		hpScript =  GameObject.Find ("Sperm").GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI()
	{
		if (hpScript.health > 75 && hpScript.health <= 101) 
		{
			GUILayout.Label(healthArray[2]);
		}
		else
		{
			if (hpScript.health > 50 && hpScript.health <= 75)
			{
				GUILayout.Label(healthArray[1]);
			}
			else
			{
				if (hpScript.health > 25 && hpScript.health <= 50)
				{
					GUILayout.Label(healthArray[0]);
				}

			}
		}
	}
}
