using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float bulletSpeed = 10f;
	public float bulletTime = 1f;

	// Use this for initialization
	void Start () {
		GameObject BulletSpawner = GameObject.Find ("BulletSpawner");
		GameObject hero = GameObject.Find ("Hero");
		ControllerPlayer cp = hero.GetComponent<ControllerPlayer> ();
		
		if (cp.GetFacingRight() == false)
			bulletSpeed *= -1;
		gameObject.transform.position = BulletSpawner.transform.position;
		
		rigidbody2D.velocity = new Vector2(bulletSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		bulletTime -= Time.deltaTime;
		if (bulletTime <= 0)
			Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		print (coll.gameObject.tag);
		//Destroy(coll.gameObject);
	}
}
