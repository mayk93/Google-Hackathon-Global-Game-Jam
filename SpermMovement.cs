using UnityEngine;
using System.Collections;

public class SpermMovement : MonoBehaviour {

	public GameObject spermObject;
	public float velocityRatio = 5f;

	public GameObject emptyGameObject;

	public Sprite [] spriteArray;

	int spriteCount;

	void Start ()
	{
		spriteCount = 0;
		InvokeRepeating ("AnimateSperm", 0.3f , 0.3f);
	}

	void AnimateSperm()
	{
		spermObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [spriteCount];
		spriteCount = spriteCount + 1;
		if (spriteCount >= 4) 
		{
			spriteCount = 0;
		}
	}

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

			spermObject.rigidbody2D.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 50));

			Vector3 cameraPosition = Camera.main.transform.position;

			//Camera.main.GetComponent<SmoothFollow2D>().targetY = mouseWorldPos3D.y;

			if(cameraPosition.y < mouseWorldPos3D.y - 3)
			{
				Camera.main.GetComponent<SmoothFollow2D>().targetY = mouseWorldPos3D.y;
				Camera.main.GetComponent<SmoothFollow2D>().targetX = mouseWorldPos3D.x;
			}

			spermObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [spriteCount];
			
			spriteCount = spriteCount + 1;
			if (spriteCount >= 4) 
			{
				spriteCount = 0;
			}
		}

		//spermObject.rigidbody2D.gravityScale = spermObject.rigidbody2D.velocity.magnitude;
	}

}
