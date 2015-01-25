#pragma strict

var movieTexture : MovieTexture;

function Start () {
	renderer.material.mainTexture = movieTexture;
	movieTexture.Play();
}

function Update () {
	if(movieTexture.isPlaying == false)
	{
		Application.LoadLevel(1);
	}
}