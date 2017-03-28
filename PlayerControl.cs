using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	Rigidbody2D rb2d;
	Vector3 jumpforce;
	bool grounded;
	float animspeed;

	// Use this for initialization
	void Start () {
		animspeed = 1.2f;
		rb2d = GetComponent<Rigidbody2D> ();
		jumpforce = new Vector3(0f,8f,0f);

	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.GetComponent<Animator> ().speed = animspeed;
		Jump ();
	
	}

	void Jump() {
		#if UNITY_EDITOR
		if (rb2d.position.y < -3.325f && rb2d.position.y > -3.330f)
			grounded = true;
		if (grounded && Input.GetMouseButtonDown(0)) {
			rb2d.AddForce(jumpforce, ForceMode2D.Impulse);
			grounded = false;
		}
		//#endif
		#else
		if (rb2d.position.y < -3.325f && rb2d.position.y > -3.330f)
			grounded = true;
		if (grounded && Input.touchCount > 0) {
			Vector2 touch = Input.GetTouch(0).position;
			if (touch.x < Screen.width*0.850f || touch.y < Screen.height*0.850f) {
				rb2d.AddForce(jumpforce, ForceMode2D.Impulse);
				grounded = false;
			}
		}
		#endif
	}
}
