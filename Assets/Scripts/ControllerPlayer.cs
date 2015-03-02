using UnityEngine;
using System.Collections;

public class ControllerPlayer : MonoBehaviour {

	public float moveSpeed = 5f;
	public float jumpForce = 1000f;
	public GameObject bullet;

	private bool isFacingRight= true;
	private bool isDuck = false;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		ControllerKey ();
	}

	void ControllerKey() {
		bool walkRight = Input.GetKey (KeyCode.RightArrow);
		bool walkLeft = Input.GetKey (KeyCode.LeftArrow);
		bool duck = Input.GetKeyDown (KeyCode.A);
		bool jump = Input.GetKeyDown (KeyCode.Space);
		bool shoot = Input.GetKeyDown (KeyCode.S);

		if (shoot && !isDuck) {
			Instantiate(bullet);
		}
		
		if (duck) {
			if (!isDuck) {
				isDuck = true;
				animator.SetBool("DuckToggle", true);
			} else {
				isDuck = false;
				animator.SetBool("DuckToggle", false);
			}
		}
		
		if (walkRight) {
			if (!isFacingRight) Flip ();
			if (!isDuck) {
				animator.SetBool("WalkToggle", true);
				rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
			}
		} else if (walkLeft) {
			if (isFacingRight) Flip ();
			if (!isDuck) {
				animator.SetBool("WalkToggle", true);
				rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
			}
		} else {
			animator.SetBool("WalkToggle", false);
			rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
		}
		
		if (jump && rigidbody2D.velocity.y == 0 && !isDuck)
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
	}
	
	void Flip() {
		isFacingRight = !isFacingRight;
		Vector3 vec3 = this.transform.localScale;
		vec3.x *= -1;
		this.transform.localScale = vec3;
	}
	
	public bool GetFacingRight () {
		return isFacingRight;
	}
}
