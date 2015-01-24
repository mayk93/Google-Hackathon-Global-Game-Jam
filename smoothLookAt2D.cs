using UnityEngine;
using System.Collections;

public class smoothLookAt2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public GameObject target;
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 currentPosition = transform.position;
		currentPosition.y = Mathf.Lerp (transform.position.y, target.transform.position.y, 1f * Time.deltaTime);
		currentPosition.x = Mathf.Lerp (transform.position.x, target.transform.position.x, 1f * Time.deltaTime);
		transform.position = currentPosition;
	}
}
