/*
using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {

	public bool useSpring = false;

	Rigidbody2D grabbedObject = null;
	SpringJoint2D springJoint = null;

	float dragSpeed = 10f;
	float velocityRatio = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			// If I am here, it means I clicked.

			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2( mouseWorldPos3D.x , mouseWorldPos3D.y );

			Vector2 dir        = Vector2.zero;

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D,dir);

			// If hit is not null, the raycast returned an object containing information about what we hit
			if( hit != null && hit.collider != null )
			{
				// If the hit object has a rigidbody
				if(hit.collider.rigidbody2D != null )
				{
					grabbedObject = hit.collider.rigidbody2D;
					grabbedObject.rigidbody2D.gravityScale = 1;

					if ( useSpring == true )
					{
						this.springJoint = grabbedObject.gameObject.AddComponent<SpringJoint2D>();
						//Set the anchor to the position of the object we clicked
						Vector3 localHitPoint = grabbedObject.transform.InverseTransformPoint(hit.point);
						this.springJoint.anchor = new Vector2(localHitPoint.x,localHitPoint.y);
						
						springJoint.distance = 0.025f;
						springJoint.dampingRatio = 5f;
						springJoint.frequency = 5f;
						
						springJoint.collideConnected = true;
					}
					else
					{
						grabbedObject.gravityScale = 0;
					}

				}
			}
		}

		if (Input.GetMouseButtonUp (0) && grabbedObject != null) 
		{
			if(useSpring == true)
			{
				Destroy(this.springJoint);
			}
			else
			{
				grabbedObject.gravityScale = 1;
			}

			grabbedObject = null;
		}
	}

	void FixedUpdate()
	{
		if (grabbedObject != null) 
		{
			Vector2 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if(useSpring && springJoint != null)
			{
				springJoint.connectedAnchor = mouseWorldPos3D;
			}
			else
			{	
				grabbedObject.velocity = (mouseWorldPos3D - grabbedObject.position) * velocityRatio;
			}
		}
	}

	void LateUpdate()
	{
		if (springJoint != null) 
		{
			Vector3 worldAnchor = grabbedObject.transform.TransformPoint(springJoint.anchor);		
		}
	}

}

 */

using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

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
