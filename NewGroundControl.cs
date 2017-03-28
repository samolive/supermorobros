using UnityEngine;
using System.Collections;

public class NewGroundControl : MonoBehaviour {

	private Transform tf;
	GameObject control;
	public GameObject[] gdtiles;
	float spd;
	float posx;
	float posy;
	float posz;

	// Use this for initialization
	void Start () {
		control = GameObject.Find ("LevelControl");
		tf = GetComponent<Transform> ();
		posx = tf.position.x;
		posy = tf.position.y;
		posz = tf.position.z;
	}

	// Update is called once per frame
	void Update () {
		LevelControl lc = control.GetComponent<LevelControl> ();
		spd = lc.speed;
		posx -= spd * Time.deltaTime;
		tf.position = new Vector3 (posx, posy, posz);

		if (posx < -23f) {
			Vector3 spawn = new Vector3(45.6f,-1.5f,0);
			Instantiate (gdtiles[UnityEngine.Random.Range(0,9)], spawn, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}