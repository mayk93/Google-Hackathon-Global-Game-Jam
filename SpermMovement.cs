using UnityEngine;
using System.Collections;

public class SpermMovement : MonoBehaviour {

	public GameObject spermObject;
	public float velocityRatio = 10f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2( mouseWorldPos3D.x , mouseWorldPos3D.y );
			
			spermObject.rigidbody2D.velocity = (mousePos2D - spermObject.rigidbody2D.position) * velocityRatio;
		}
	}
}
