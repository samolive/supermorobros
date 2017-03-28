using UnityEngine;
using System.Collections;

public class PowerupControl : MonoBehaviour {
	Transform tf;
	Collider2D col;
	Rigidbody2D rb2d;
	//public Collider2D playercol;
	GameObject control;
	float spd;
	float posx;
	float posy;
	float posz;
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
		posx -= spd * Time.deltaTime;
		tf.position = new Vector3 (posx, posy, posz);
		if (posx < -15)
			Destroy(this.gameObject);
		if (posx < -4.5f) {
			rb2d.isKinematic = true;
			col.isTrigger = true;
		}
	}
	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.tag == "Ground") {
			rb2d.isKinematic = true;
			col.isTrigger = true;
		}
	}
	void Normal(){
		LevelControl lc = control.GetComponent<LevelControl> ();
		lc.speed = 5.0f;
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		LevelControl lc = control.GetComponent<LevelControl> ();
		if (other.tag == "Player") {
			lc.speed = 8.0f;
			this.GetComponent<AudioSource> ().Play ();
			Invoke ("Normal", 0.5f);
			this.GetComponent <Renderer>().enabled = false;
		}
	}
}
