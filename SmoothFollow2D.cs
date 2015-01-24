using UnityEngine;
using System.Collections;

public class SmoothFollow2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public float targetY = 0f;
	public float targetX = 0f;

	// Update is called once per frame
	void Update ()
	{
		Vector3 currentPosition = transform.position;
		currentPosition.y = Mathf.Lerp (transform.position.y, targetY, 1 * Time.deltaTime);
		currentPosition.x = Mathf.Lerp (transform.position.x, targetX, 1 * Time.deltaTime);
		transform.position = currentPosition;
	}
}
