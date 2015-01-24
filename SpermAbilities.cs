using UnityEngine;
using System.Collections;

public class SpermAbilities : MonoBehaviour {

	public GameObject spermObject;
	public GameObject projectile;
	public Sprite projectileSprite;
	public GameObject explosionEffect;
	public float velocityRatio = 15f;

	public AudioClip[] shotSounds;

	public float coolDown;
	private bool shootOk;

	float _buttonDownPhaseStart;
	float _doubleClickPhaseStart;

	float bonus = 10f;

	// Use this for initialization
	void Start () {
		shootOk = true;
		coolDown = 1f;
	}

	/*
	// Update is called once per frame
	void Update () {
		int nbTouches = Input.touchCount;

		Debug.Log("TOUCHES!!!" + nbTouches);
		print ("TOUCHES!!!" + nbTouches);
		Debug.Log("shootOk!!!" + shootOk);

		if (nbTouches > 0 && shootOk == true) 
		{
			Debug.Log("Here cooldown begin");
			print ("X TOUCHES!!!" + nbTouches);
			shootOk = false;

			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2( mouseWorldPos3D.x , mouseWorldPos3D.y );

			GameObject spermProjectile = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
			SpriteRenderer spermProjectileeSpriteRenderer = spermProjectile.AddComponent<SpriteRenderer>();
			spermProjectileeSpriteRenderer.sprite = projectileSprite;
			Rigidbody2D spermProjectileRidgidBody2D = spermProjectile.AddComponent<Rigidbody2D> ();
			spermProjectileRidgidBody2D.gravityScale = 0.1f;
			PolygonCollider2D spermProjectilePolygonCollider2D = spermProjectile.AddComponent<PolygonCollider2D> ();
			SelfDestroy spermProjectileSelfDestroy = spermProjectile.AddComponent<SelfDestroy> ();
			spermProjectileSelfDestroy.explosion = explosionEffect;

			spermProjectile.rigidbody2D.velocity = (mousePos2D - spermObject.rigidbody2D.position) * velocityRatio;

			Invoke( "shootOKAgain", coolDown );
		}
	}
	*/

	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			_buttonDownPhaseStart = Time.time;
		}
		if (_doubleClickPhaseStart > -1 && (Time.time - _doubleClickPhaseStart) > 0.2f)
		{
			_doubleClickPhaseStart = -1;

		}
		if( Input.GetMouseButtonUp(0) )
		{
			if(Time.time - _buttonDownPhaseStart > 1.0f)
			{
				//Debug.Log ("long click");
				_doubleClickPhaseStart = -1;
			}
			else
			{
				if (Time.time - _doubleClickPhaseStart < 0.2f && shootOk == true)
				{
					/* Start Shoot Mechanic */

					shootOk = false;

					//print(shootOk);
					
					Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					Vector2 mousePos2D = new Vector2( mouseWorldPos3D.x , mouseWorldPos3D.y );
					
					GameObject spermProjectile = (GameObject)Instantiate(projectile, new Vector3(transform.position.x,transform.position.y + 1,-1), transform.rotation);
					SpriteRenderer spermProjectileeSpriteRenderer = spermProjectile.AddComponent<SpriteRenderer>();
					spermProjectileeSpriteRenderer.sprite = projectileSprite;
					Rigidbody2D spermProjectileRidgidBody2D = spermProjectile.AddComponent<Rigidbody2D> ();
					spermProjectileRidgidBody2D.gravityScale = 0f;
					PolygonCollider2D spermProjectilePolygonCollider2D = spermProjectile.AddComponent<PolygonCollider2D> ();

					GameObject spermProjectileParticle = (GameObject)Instantiate(explosionEffect,new Vector3(transform.position.x,transform.position.y,transform.position.z-1),transform.rotation);
					spermProjectileParticle.transform.parent = spermProjectile.transform;

					spermProjectile.rigidbody2D.velocity = transform.TransformDirection(Vector3.up * velocityRatio);
					spermProjectileParticle.rigidbody2D.velocity = transform.TransformDirection(Vector3.up * velocityRatio);

					audio.clip = shotSounds[Random.Range(0,shotSounds.Length-1)];
					audio.Play();

					//spermProjectile.rigidbody2D.

					Invoke( "shootOKAgain", coolDown );

					/* End Shoot Mechanic */

					_doubleClickPhaseStart = -1;
				}
				else
				{
					_doubleClickPhaseStart = Time.time;
				}
			}
		}
	}
	
	void shootOKAgain()
	{
		shootOk = true;
	}
}
