using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public void loadScene(int sceneNumber)
	{
		if ( GameObject.Find("ToggleX").GetComponent<Toggle>().isOn == true )
		{
			Application.LoadLevel (sceneNumber+1);
		}
		else
		{
			Application.LoadLevel (sceneNumber);
		}
	}
	
	public void quit()
	{
		Application.Quit ();
	}
}
