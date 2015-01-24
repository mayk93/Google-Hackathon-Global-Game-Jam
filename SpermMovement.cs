using UnityEngine;
using System.Collections;

public class SpermMovement : MonoBehaviour {

	public GameObject spermObject;
	public float velocityRatio = 1f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		float lSpeed = 100.0f; // Set this to a value you like

		if (Input.GetMouseButtonDown (0)) 
		{
			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2( mouseWorldPos3D.x , mouseWorldPos3D.y );

			spermObject.transform.rotation = Quaternion.Lerp ( spermObject.transform.rotation, Quaternion.Euler(mouseWorldPos3D), Time.deltaTime*lSpeed);

			spermObject.rigidbody2D.velocity = (mousePos2D - spermObject.rigidbody2D.position) * velocityRatio;

			//spermObject.rigidbody2D.transform.LookAt(mouseWorldPos3D);
		}
	}
}
