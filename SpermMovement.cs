using UnityEngine;
using System.Collections;

public class SpermMovement : MonoBehaviour {

	public GameObject spermObject;
	public float velocityRatio = 1f;

	public GameObject emptyGameObject;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2( mouseWorldPos3D.x , mouseWorldPos3D.y );

			spermObject.rigidbody2D.velocity = (mousePos2D - spermObject.rigidbody2D.position) * velocityRatio;

			float cameraDif = Camera.main.transform.position.y - transform.position.y;
			float mouseX = Input.mousePosition.x;
			float mouseY = Input.mousePosition.y;
			Vector3 mWorldPos = new Vector3(mouseX, mouseY, cameraDif);
			Vector3 mainPos = Camera.main.transform.position;
			float diffX = mWorldPos.x - mainPos.x;
			float diffY = mWorldPos.y - mainPos.y;
			float angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg;

			Debug.Log(angle);

			spermObject.rigidbody2D.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 50));

			Vector3 cameraPosition = Camera.main.transform.position;

			if(cameraPosition.y < mouseWorldPos3D.y)
			{
				Camera.main.GetComponent<SmoothFollow2D>().targetY = mouseWorldPos3D.y;
			}
		}
	}

}
