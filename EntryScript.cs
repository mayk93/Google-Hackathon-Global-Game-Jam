using UnityEngine;
using System.Collections;

public class EntryScript : MonoBehaviour {

	public MovieTexture movieFile;
	public AudioClip audioFile;
	public GameObject planeOfProjection;

	// Use this for initialization
	void Start () {
		planeOfProjection.renderer.material.mainTexture = movieFile;
	}
	
	// Update is called once per frame
	void Update () {
		movieFile.Play();
	}
}
