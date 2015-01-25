using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public void loadScene(int sceneNumber)
	{
		if ( GameObject.Find("ToggleX").GetComponent<Toggle>().isOn == true )
		{
			Application.LoadLevel ("movie");
		}
		else
		{
			Application.LoadLevel ("beforePlay");
		}
	}
	
	public void quit()
	{
		Application.Quit ();
	}
}
