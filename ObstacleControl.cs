using UnityEngine;
using System.Collections;

public class ObstacleControl : MonoBehaviour {
	Transform tf;
	Collider2D col;
	Rigidbody2D rb2d;
	//public Collider2D playercol;
	//public Collider2D gdcol;
	GameObject control;
	float spd;
	float posx;
	float posy;
	float posz;
	bool grounded = false;
	// Use this for initialization
	void Start () {
		control = GameObject.Find ("LevelControl");
		tf = GetComponent<Transform> ();
		col = GetComponent<Collider2D> ();
		rb2d = GetComponent<Rigidbody2D> ();
		posz = tf.position.z;	
	}
	
	// Update is called once per frame
	void Update () {
		Behaviour ();

	
	}

	void Behaviour(){
		LevelControl lc = control.GetComponent<LevelControl> ();
		spd = lc.speed;
		posy = tf.position.y;
		posx = tf.position.x;
		if (grounded) {
			posx -= spd * Time.deltaTime;
			tf.position = new Vector3 (posx, posy, posz);
		}
		if (posx < -15)
			Destroy(this.gameObject);
	}
	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.tag == "Ground") {
			rb2d.isKinematic = true;
			col.isTrigger = true;
			grounded = true;
		}

	}

	void Normal(){
		LevelControl lc = control.GetComponent<LevelControl> ();
		lc.speed = 5.0f;
	}

	void OnTriggerEnter2D(Collider2D other) {
		LevelControl lc = control.GetComponent<LevelControl> ();
		if (other.tag == "Player") {
			lc.speed = 1.0f;
			Invoke ("Normal", 0.5f);
		}
	}
}
