using UnityEngine;
using System.Collections;

public class SpermAbilities : MonoBehaviour {

	public GameObject spermObject;
	public GameObject projectile;
	public Sprite projectileSprite;
	public ParticleSystem explosionEffect;
	public float velocityRatio = 5f;

	public float coolDown;
	public float remainingTime;

	// Use this for initialization
	void Start () {
		remainingTime = 0f;
		coolDown = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		int nbTouches = Input.touchCount;


		Debug.Log(nbTouches);

		if (nbTouches == 2 && remainingTime =< 0) 
		{
			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2( mouseWorldPos3D.x , mouseWorldPos3D.y );

			GameObject spermProjectile = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
			SpriteRenderer spermProjectileeSpriteRenderer = spermProjectile.AddComponent<SpriteRenderer>();
			spermProjectileeSpriteRenderer.sprite = projectileSprite;
			Rigidbody2D spermProjectileRidgidBody2D = spermProjectile.AddComponent<Rigidbody2D> ();
			spermProjectileRidgidBody2D.gravityScale = 0f;
			PolygonCollider2D spermProjectilePolygonCollider2D = spermProjectile.AddComponent<PolygonCollider2D> ();
			SelfDestroy spermProjectileSelfDestroy = spermProjectile.AddComponent<SelfDestroy> ();
			spermProjectileSelfDestroy.explosion = explosionEffect;

			spermProjectile.rigidbody2D.velocity = (mousePos2D - spermObject.rigidbody2D.position) * velocityRatio;

			remainingTime = coolDown - Time.deltaTime;
		}
	}
}
